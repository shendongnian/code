    public static class CollectionsClass
    {
        public static List<Object1> list1 = new List<Object1>();
        public static List<Object2> list2 = new List<Object2>();
        public static List<Object3> list3 = new List<Object3>();
    }
    public static class ActionClass
    {
        private static void Populate<T>(List<T> list, int minLimit, int maxLimit)
            where T : new()
        {
            var rnd = new Random();
            int rndNum = rnd.Next(minLimit, maxLimit);
            for (int i = 0; i < rndNum; i++)
            {
                list.Add(new T());
            }
        }
    
        public static void PopulateCollections()
        {
            var fields = typeof(CollectionsClass).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            foreach (var field in fields)
            {
                var method = typeof(ActionClass).GetMethod("Populate", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).MakeGenericMethod(field.FieldType.GenericTypeArguments[0]);
                method.Invoke(null, System.Reflection.BindingFlags.Static, null, new object[] { field.GetValue(null), 0, 1000 }, Thread.CurrentThread.CurrentCulture);
            }
        }
    }
