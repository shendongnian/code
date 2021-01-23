            /// <summary>
            /// Gets the initialize generic list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public IList<T> GetInitializeGenericList<T>() where T : class
            {
                Type t = typeof(List<>);
                Type typeArgs =typeof(T);
                Type type = t.MakeGenericType(typeArgs);
                // Create the List according to Type T
                dynamic reportBlockEntityCollection = Activator.CreateInstance(type);
                // If you want to pull the data into initialized list you can fill the data
                //dynamic entityObject = Activator.CreateInstance(typeArgs);
    
                //reportBlockEntityCollection.Add(entityObject);
    
                return reportBlockEntityCollection;
            }
