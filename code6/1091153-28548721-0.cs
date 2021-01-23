        public List<T> GetAll(String[] include)
        {
            IQueryable<T> outQuery = ObjectSet;
            foreach (String s in include)
            {
                outQuery = outQuery.Include(s);
            }
            return outQuery.ToList();
        }
