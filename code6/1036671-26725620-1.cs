    using Orient.Client;
    using Orient.Client.Mapping;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    namespace MyApplication
    {
        /// <summary>
        /// Provides extension methods for <see cref="Orient.Client.ODatabase"/>
        /// </summary>
        public static class DatabaseExtensions
        {
            private const int SINGLE_RID_TARGET_PATTERN_INDEX = 3;
            private static readonly string[] legalTargets = {
                @"^(?:class:)?[a-zA-Z][a-zA-Z0-9]*$",       // Class
                @"^cluster:\d+$",                           // Root cluster
                @"^\[(?:#\d+:\d+\s*,?\s*)*(?:#\d+:\d+)\]$", // Array of RIDs
                @"^#\d+:\d+$"                               // Single root record RID
            };
    
            /// <summary>
            /// Fills out a collection of models of type <typeparamref name="T"/> using <c>traverse</c>. <paramref name="db"/> must be open.
            /// </summary>
            /// <remarks>
            /// <para>Note that <c>traverse</c> can be slow, and <c>select</c> may be more appropriate. See
            /// http://www.orientechnologies.com/docs/last/orientdb.wiki/SQL-Traverse.html#should-i-use-traverse-or-select
            /// </para>
            /// <para>Lightweight edges are not followed when populating model properties. Make sure to use "heavyweight" edges with either
            /// <c>alter property MyEdgeClass.out MANDATORY=true</c> and <c>alter property MyEdgeClass.in MANDATORY=true</c>, or else
            /// use <c>alter database custom useLightweightEdges=false</c>.</para>
            /// </remarks>
            /// <typeparam name="T">The model type. Must extend <see cref="ABaseModel"/>, have a parameterless constructor, and most importantly it must be in the same
            /// namespace as <see cref="ABaseModel"/>.</typeparam>
            /// <param name="db">The database to query</param>
            /// <param name="from">A class, cluster, RID list, or RID to traverse. RIDs are in the form <c>#clusterId:clusterPosition</c>. Lists are in the form
            /// <c>[RID,RID,...]</c> with one or more elements (whitespace is ignored). Clusters are in the form <c>cluster:clusterName</c> or <c>cluster:clusterId</c>.</param>
            /// <exception cref="System.ArgumentException">If <paramref name="from"/> is an invalid format</exception>
            /// <returns>An enumerable collection of models of type <typeparamref name="T"/>. Public instance properties of the models will have their values populated
            /// based on all non-lightweight edges in the traversal.</returns>
            public static IEnumerable<T> Traverse<T>(this ODatabase db, string from) where T : ABaseModel, new()
            {
                // Sanity check on target
                bool matches = false;
                foreach (string pattern in legalTargets)
                {
                    if (Regex.IsMatch(from, pattern))
                    {
                        matches = true;
                        break;
                    }
                }
                if (!matches)
                {
                    throw new ArgumentException("Traverse target must be a class, cluster, RID list, or single RID.", "from");
                }
                bool fromSingleRecord = Regex.IsMatch(from, legalTargets[SINGLE_RID_TARGET_PATTERN_INDEX]);
                // Traverse DB
                string sql = string.Format("traverse * from {0}", from);
                List<ODocument> result = db.Query(sql);
                DatabaseTraversal traversal = new DatabaseTraversal(db, result);
                // Process result
                IEnumerable<T> models = traversal.ToModel<T>();
                if (fromSingleRecord)
                {
                    // Either Traverse(ORID) was called, or client code called Traverse with an RID string -- return a single element
                    models = models.Where(m => m.ORID.ToString().Equals(from));
                }
                return models;
            }
            /// <summary>
            /// Fills out a model of type <typeparamref name="T"/> using <c>traverse</c>. <paramref name="db"/> must be open.
            /// </summary>
            /// <remarks>
            /// <para>Note that <c>traverse</c> can be slow, and <c>select</c> may be more appropriate. See
            /// http://www.orientechnologies.com/docs/last/orientdb.wiki/SQL-Traverse.html#should-i-use-traverse-or-select
            /// </para>
            /// <para>Lightweight edges are not followed when populating model properties. Make sure to use "heavyweight" edges with either
            /// <c>alter property MyEdgeClass.out MANDATORY=true</c> and <c>alter property MyEdgeClass.in MANDATORY=true</c>, or else
            /// use <c>alter database custom useLightweightEdges=false</c>.</para>
            /// </remarks>
            /// <typeparam name="T">The model type. Must extend <see cref="ABaseModel"/>, have a parameterless constructor, and most importantly it must be in the same
            /// namespace as <see cref="ABaseModel"/>.</typeparam>
            /// <param name="db">The database to query</param>
            /// <param name="from">The root RID to traverse.</param>
            /// <returns>A model representing the record indicated by <paramref name="from"/>.</returns>
            public static T Traverse<T>(this ODatabase db, ORID from) where T : ABaseModel, new()
            {
                // Traverse<T>(from.ToString()) is guaranteed to have 0 or 1 elements
                return db.Traverse<T>(from.ToString()).SingleOrDefault();
            }
            /// <summary>
            /// Helper class for traversing <see cref="Orient.Client.ODatabase"/>
            /// </summary>
            private class DatabaseTraversal
            {
                private IEnumerable<ODocument> documents;
                private IEnumerable<OEdge> edges;
                private IDictionary<ORID, ODocument> documentMap;
                private static readonly Func<Type, bool> isModelPropertyEnumerableHelper = pType => typeof(System.Collections.IEnumerable).IsAssignableFrom(pType);
                private static readonly Func<PropertyInfo, string> isModelPropertyHelper = pInfo =>
                {
                    string alias = pInfo.Name;
                    OProperty propertyAlias = pInfo.GetCustomAttributes(typeof(OProperty)).Where(attr => !string.IsNullOrEmpty(((OProperty)attr).Alias)).SingleOrDefault() as OProperty;
                    if (propertyAlias != null)
                    {
                        alias = propertyAlias.Alias;
                    }
                    return alias;
                };
                private static readonly Action<dynamic, dynamic, string> setPropertiesHelper = (parent, child, className) =>
                {
                    PropertyInfo[] properties = parent.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.GetProperty);
                    PropertyInfo propertySingle = properties.Where(prop => IsModelProperty(prop, className)).SingleOrDefault();
                    PropertyInfo propertyCollection = properties.Where(prop => IsModelCollectionProperty(prop, className)).SingleOrDefault();
                    if (propertySingle != null)
                    {
                        propertySingle.SetValue(parent, child);
                    }
                    else if (propertyCollection != null)
                    {
                        dynamic propertyValue = propertyCollection.GetValue(parent);
                        if (propertyValue == null)
                        {
                            Type listOfT =  typeof(List<>).MakeGenericType(propertyCollection.PropertyType.GenericTypeArguments[0]);
                            IEnumerable collection = (IEnumerable)Activator.CreateInstance(listOfT);
                            propertyValue = collection;
                            propertyCollection.SetValue(parent, collection);
                        }
                        propertyValue.Add(child);
                    }
                };
                /// <summary>
                /// Create new <see cref="DatabaseTraversal"/> object. <paramref name="database"/> must be open.
                /// </summary>
                /// <param name="database">Database to traverse. Required for discovering edges.</param>
                /// <param name="documents">Documents produced by <c>traverse * from $target</c></param>
                public DatabaseTraversal(ODatabase database, IEnumerable<ODocument> documents)
                {
                    this.documents = documents;
                    documentMap = documents.ToDictionary<ODocument, ORID>(doc => doc.ORID);
                    // Need to know which RIDs in documentMap are edges
                    edges = database.Select().From("E").ToList<OEdge>().Where(edge => documentMap.ContainsKey(edge.ORID));
                }
                /// <summary>
                /// Populate model object(s)
                /// </summary>
                /// <typeparam name="T">Type of model to return</typeparam>
                /// <returns>A collection of model objects which appear in the traversal.</returns>
                public IEnumerable<T> ToModel<T>() where T : ABaseModel, new()
                {
                    if (documents.Count() == 0) return null;
                    IDictionary<ORID, ABaseModel> models = new Dictionary<ORID, ABaseModel>();
                    foreach (OEdge e in edges)
                    {
                        ODocument outDoc = documentMap[e.OutV];
                        ODocument inDoc = documentMap[e.InV];
                        dynamic outModel, inModel;
                        bool containsOutId = models.ContainsKey(outDoc.ORID);
                        bool containsInId = models.ContainsKey(inDoc.ORID);
                        // Set the value for the models that edge is pointing into/out of
                        if (containsOutId)
                        {
                            outModel = models[outDoc.ORID];
                        }
                        else
                        {
                            outModel = GetNewPropertyModel(typeof(T).Namespace, outDoc.OClassName);
                            MapProperties(outDoc, outModel);
                            models.Add(outModel.ORID, outModel);
                        }
                        if (containsInId)
                        {
                            inModel = models[inDoc.ORID];
                        }
                        else
                        {
                            inModel = GetNewPropertyModel(typeof(T).Namespace, inDoc.OClassName);
                            MapProperties(inDoc, inModel);
                            models.Add(inDoc.ORID, inModel);
                        }
                        // Set the property values for outModel to inModel if they exist
                        setPropertiesHelper(outModel, inModel, e.OClassName);
                        setPropertiesHelper(inModel, outModel, e.OClassName);
                    }
                    // Return models of type T
                    IEnumerable<T> result = models.Select(kvp => kvp.Value).Where(model => model.OClassName.Equals(typeof(T).Name)).Cast<T>();
                    return result;
                }
                /// <summary>
                /// Map non-edge properties of the vertex to the model
                /// </summary>
                /// <typeparam name="T">The model type</typeparam>
                /// <param name="document">The vertex</param>
                /// <param name="resultObj">The model object</param>
                private static void MapProperties<T>(ODocument document, T resultObj)
                {
                    (TypeMapperBase.GetInstanceFor(typeof(T)) as TypeMapper<T>).ToObject(document, resultObj);
                }
                /// <summary>
                /// Create a new instance of a model type
                /// </summary>
                /// <param name="nSpace">The model's namespace</param>
                /// <param name="modelName">The model's class name</param>
                /// <returns>A newly-initialized instance of the class <c>nSpace.modelName</c></returns>
                private static dynamic GetNewPropertyModel(string nSpace, string modelName)
                {
                    Type modelClass = Type.GetType(string.Format("{0}.{1}", nSpace, modelName));
                    return modelClass.GetConstructor(Type.EmptyTypes).Invoke(null);
                }
                /// <summary>
                /// Checks whether the given property or its alias is a vertex's class name and is not enumerable
                /// </summary>
                /// <param name="currentProperty">The property to compare name/alias against. Aliases should be set with <see cref="Orient.Client.OProperty"/></param>
                /// <param name="name">The vertex class name to compare against</param>
                /// <returns><see langword="true"/> if <paramref name="currentProperty"/> is named <paramref name="namne"/> or has an <see cref="Orient.Client.OProperty"/>
                /// attribute with an alias of <paramref name="name"/>, and <paramref name="currentProperty"/> is not a collection type.</returns>
                private static bool IsModelProperty(PropertyInfo currentProperty, string name)
                {
                    string alias = isModelPropertyHelper(currentProperty);
                    return !isModelPropertyEnumerableHelper(currentProperty.PropertyType) && alias.Equals(name);
                }
                /// <summary>
                /// Checks whether the given property or its alias is a vertex's class name and is enumerable
                /// </summary>
                /// <param name="currentProperty">The property to compare name/alias against. Aliases should be set with <see cref="Orient.Client.OProperty"/></param>
                /// <param name="name">The vertex class name to compare against</param>
                /// <returns><see langword="true"/> if <paramref name="currentProperty"/> is named <paramref name="namne"/> or has an <see cref="Orient.Client.OProperty"/>
                /// attribute with an alias of <paramref name="name"/>, and <paramref name="currentProperty"/> is a collection type.</returns>
                private static bool IsModelCollectionProperty(PropertyInfo currentProperty, string name)
                {
                    string alias = isModelPropertyHelper(currentProperty);
                    return isModelPropertyEnumerableHelper(currentProperty.PropertyType) && alias.Equals(name);
                }
            }
        }
    }
