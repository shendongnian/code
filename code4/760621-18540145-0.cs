        public void getItems(Type t, List<object> list)
        {
           foreach(FieldInfo fi in t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
           {
               list.Add(fi.Name);
               if(!fi.FieldType.Namespace.Equals("System"))
               {
                   List<object> newList = new List<object>();
                   list.Add(newList);
                   getItems(fi.FieldType, newList);
               }
           }
        }
