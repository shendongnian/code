        public async Task<Entity[]> GetAsync()
        {
            using (var context = new DataContext())
            {
                Entity[] es = await context.Entities.Where(e => e.Status == Status.Pending).ToArrayAsync();
                return es;
            }
        }
