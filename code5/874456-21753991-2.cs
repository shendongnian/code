        private static T BaseDeepCopy<T>(this T source)
        {
            try
            {
                //Throw if passed object has nothing
                if (source == null) { throw new Exception("Null Object cannot be cloned"); }
                // Don't serialize a null object, simply return the default for that object
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }
                //variable declaration
                T copy;
                var obj = new DataContractSerializer(typeof(T));
                using (var memStream = new MemoryStream())
                {
                    obj.WriteObject(memStream, source);
                    memStream.Seek(0, SeekOrigin.Begin);
                    copy = (T)obj.ReadObject(memStream);
                }
                return copy;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This method used to deep copy of a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityCollection"></param>
        /// <returns></returns>
        public static ObservableCollection<T> DeepCopy<T>(this ObservableCollection<T> entityCollection)
        {
            try
            {
                Type t = entityCollection.GetType();
                ObservableCollection<T> RooTList = new ObservableCollection<T>();
                foreach (T objEntity in entityCollection)
                {
                    T iObject = DeepCopy(objEntity);
                    RooTList.Add(iObject);
                }
                return RooTList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// this method used to create deep copy of any Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSource"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T objSource)
        {
            try
            {
                //Get the type of source object  
                Type typeSource = objSource.GetType();
                // create a new instance of that type by deep copy
                T objTarget = objSource.BaseDeepCopy();
                //Get all the properties of source object type
                List<PropertyInfo> propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(m => m.PropertyType.IsGenericType && m.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>)).ToList();
                //Assign all source property to taget object 's properties
                foreach (PropertyInfo property in propertyInfo)
                {
                    Type t1 = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    dynamic safeValue1 = (property.GetValue(objSource, null) == null) ? null : Convert.ChangeType(property.GetValue(objSource, null), t1, null);
                    dynamic dcoll = property.GetValue(objTarget, null);
                    foreach (dynamic child in safeValue1)
                    {
                        dcoll.Add(DeepCopy(child));
                    }
                }
                return objTarget;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
