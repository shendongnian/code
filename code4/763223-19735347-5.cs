    public class XmlDocumentationProvider : IDocumentationProvider, IModelDocumentationProvider
    {
        private const string TypeExpression = "/doc/members/member[@name='T:{0}']";
        private const string PropertyExpression = "/doc/members/member[@name='P:{0}']";
    ///...
    ///... existing code
    ///...
    
        private static string GetPropertyName(PropertyInfo property)
        {
            string name = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", property.DeclaringType.FullName, property.Name);
            return name;
        }
        public IDictionary<string, TypeDocumentation> GetModelDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var retDictionary = new Dictionary<string, TypeDocumentation>();
            ReflectedHttpActionDescriptor reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
            {
                foreach (var parameterDescriptor in reflectedActionDescriptor.GetParameters())
                {
                    if (!parameterDescriptor.ParameterType.IsValueType)
                    {
                        TypeDocumentation typeDocs = new TypeDocumentation();
                        string selectExpression = String.Format(CultureInfo.InvariantCulture, TypeExpression, GetTypeName(parameterDescriptor.ParameterType));
                        var typeNode = _documentNavigator.SelectSingleNode(selectExpression);
                        if (typeNode != null)
                        {
                            XPathNavigator summaryNode;
                            summaryNode = typeNode.SelectSingleNode("summary");
                            if (summaryNode != null)
                                typeDocs.Summary = summaryNode.Value;
                        }
                        foreach (var prop in parameterDescriptor.ParameterType.GetProperties())
                        {
                            string propName = prop.Name;
                            string propDocs = string.Empty;
                            string propExpression = String.Format(CultureInfo.InvariantCulture, PropertyExpression, GetPropertyName(prop));
                            var propNode = _documentNavigator.SelectSingleNode(propExpression);
                            if (propNode != null)
                            {
                                XPathNavigator summaryNode;
                                summaryNode = propNode.SelectSingleNode("summary");
                                if (summaryNode != null) propDocs = summaryNode.Value;
                            }
                            typeDocs.PropertyDocumentation.Add(new PropertyDocumentation(propName, prop.PropertyType.Name, propDocs));
                        }
                        retDictionary.Add(parameterDescriptor.ParameterName, typeDocs);
                    }
                }
            }
            return retDictionary;
        }
    }
