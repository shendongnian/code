        private static void EditStringsOfObject(object myObj)
        {
            var fields = myObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public |
                                                   BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            fields.Where(x => x.FieldType == typeof(string) && x.GetValue(myObj) != null)
                .ToList()
                .ForEach(y => y.SetValue(myObj, SomeMethodManipulatingStrings(y.GetValue(myObj).ToString())));
            fields.Where(x => !x.FieldType.IsPrimitive && !x.FieldType.Namespace.Contains("System") && !x.FieldType.IsArray)
                .ToList()
                .ForEach(x => EditStringsOfObject(x.GetValue(myObj)));            
        }
