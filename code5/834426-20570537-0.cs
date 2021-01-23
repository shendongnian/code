        public static IList<T> MyMethod<T>(IList<T> myList, string filter)
        {
            var res = new List<T>();
    
            foreach(var el in myList)
            {
                foreach(var p in typeof(T).GetProperties())
                {
                    if (p.GetValue(el) == filter)
                    {
                        res.Add(el);
                        continue;
                    }
                }
            }
            return res;
        }
