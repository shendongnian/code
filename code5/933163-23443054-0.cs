            public void ListToHashSet()
        {
            var list = new List<string> { "abc", "efg", "abc", "efg" };
            var set = new HashSet<string>(list);
            foreach (var item in list)
                Console.WriteLine("list:{0}", item);
            foreach (var item in set)
                Console.WriteLine("set:{0}", item);
        }
