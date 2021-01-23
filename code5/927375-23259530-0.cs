            dynamic myDynamicClass = new ExpandoObject();
            
            foreach (var prop in typeof (Foo).GetProperties()) {
                Type[] typeArgs = {prop.GetType()};
                var listImplementationType = typeof (List<>).MakeGenericType(typeArgs);
                var myList = Activator.CreateInstance(listImplementationType);
                myDynamicClass[prop.Name] = myList;    
            }
