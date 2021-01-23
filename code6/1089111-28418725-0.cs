    public class Converter<T1,T2>
    {
        public static List<T1> Convert(List<T2> t2List)
        {
            List<T1> t1List = t2List.ConvertAll<T1>(Convert);
            return t1List;
        }
        
        public static T1 Convert(T2 t2)
        {
            T1 t1 = Activator.CreateInstance<T1>();
            List<PropertyInfo> t1PropertyInfos = new List<PropertyInfo>(typeof(T1).GetProperties());
            List<PropertyInfo>  t2PropertyInfos = new List<PropertyInfo>(typeof(T2).GetProperties());
            foreach (PropertyInfo pi in t1PropertyInfos)
            {
               PropertyInfo data = t2PropertyInfos.Find(p => p.Name.Equals(pi.Name));
               if (data != null)
               {
                  pi.SetValue(t1, data.GetValue(t2, new object[0]), new object[0]);
               }
           }
           return t1;
       }
   }
