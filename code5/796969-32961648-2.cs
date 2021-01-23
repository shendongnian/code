        public void Delete(Guid fooId)
        {
            using (var context = new MyDbContext())
            {
                var foo = context.Foos.Include("Bars").FirstOrDefault(foo => foo.Id == fooId);
                if (foo != null)
                {
                    context.Foos.Remove(foo);
                    context.SaveChanges();
                }
            }
        }
