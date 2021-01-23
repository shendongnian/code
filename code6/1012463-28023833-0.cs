        public Task<Entity[]> GetAsync()
        {
            using (var context = new DataContext())
            {
                return context.Entities.Where(e => e.Status == Status.Pending).ToArrayAsync();
            }
        }
