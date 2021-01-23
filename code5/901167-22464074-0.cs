    public static class CollectionsClass
    {
        public static List<Object1> list1 = new List<Object1>();
        public static List<Object2> list2 = new List<Object2>();
        public static List<Object3> list3 = new List<Object3>();
    }
    public static class ActionClass
    {
        public static void PopulateCollections()
        {
            Populate(CollectionsClass.list1, 0, 10);
            Populate(CollectionsClass.list2, 20, 50);
            Populate(CollectionsClass.list3, 30, 100);
        }
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
    }
