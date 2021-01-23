        public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
        {
            if (k == "HelloWorld")
            {
                Console.Write("Hello, World!");
                AddHourlyTask(k);
            }
