        public void DeleteAllOnSubmit<T>(IEnumerable<T> items) where T : class
        {
            foreach (var item in items)
            {
                Set<T>().Attach(item);
                Set<T>().Remove(item);
            }
            SaveChanges();
        }
