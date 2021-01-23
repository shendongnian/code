    public static class PropertyCompare<T>
    {
        public readonly static Func<T, T, List<string>> ChangedProps;
        private class PropertyComparer<T>
        {
            public Func<T, T, bool> Compare { get; set; }
            public string PropertyName { get; set; }
        }
            
        static PropertyCompare()
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var firstObject = Expression.Parameter(typeof(T), "a");
            var secondObject = Expression.Parameter(typeof(T), "b");
            PropertyComparer<T>[] propertyComparers = new PropertyComparer<T>[properties.Length];
            for (int i = 0; i < properties.Length; i++) 
            {                        
                PropertyInfo thisProperty = properties[i];
                Expression arePropertiesEqual = Expression.Equal(Expression.Property(firstObject, thisProperty), Expression.Property(secondObject, thisProperty));
                Expression<Func<T, T, bool>> equalityFunc = Expression.Lambda<Func<T, T, bool>>(arePropertiesEqual, firstObject, secondObject);
                PropertyComparer<T> comparer = new PropertyComparer<T>()
                {
                    Compare = equalityFunc.Compile(),
                    PropertyName = properties[i].Name
                };
                propertyComparers[i] = comparer;                        
            }
            ChangedProps = new Func<T,T,List<string>>((a,b) =>
            {
                List<string> changedFields = new List<string>();
                foreach (PropertyComparer<T> comparer in propertyComparers)
                {
                    if (comparer.Compare(a, b))
                        continue;
                    changedFields.Add(comparer.PropertyName);
                }
                return changedFields;
            });
        }
    }      
  
    public class Order
    {
       public int OrderNumber {get;set;}
       public DateTime OrderDate {get;set; }
       public string Something {get; set; }
    }
    static void Main(string[] args)
    {
        Order myOrder1 = new Order() { OrderDate = DateTime.Today, OrderNumber = 1, Something = "bleh" };
        Order myOrder2 = new Order() { OrderDate = DateTime.Today.AddDays(1), OrderNumber = 1, Something = "bleh" };
        List<string> changedFields = PropertyCompare<Order>.ChangedProps(myOrder1, myOrder2);
        
        Console.ReadKey();
    }
  
