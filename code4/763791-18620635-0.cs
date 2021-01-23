    public static class MyExtensions
    {
        public static void Add(this List<String> list, String param1, String param2, String param3)
        {
            list.Add(param1);
            list.Add(param2);
            list.Add(param3);
        }
    }
