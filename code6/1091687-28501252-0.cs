    object[] objectsCollection = new object[] { new StringBuilder(), new ASCIIEncoding() };
            foreach(var o in objectsCollection)
            {
                foreach(PropertyInfo pi in o.GetType().GetProperties())
                {
                    string propertyName = ((MemberInfo)pi).Name;
                    var propVal = pi.GetValue(o);
                    //here you can collect properties and values
                }
            }
