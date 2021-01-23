        public class VendorRepository : IVendorRepository
        {
            PropertyInfoEntities context = new PropertyInfoEntities();
            public IQueryable<Vendor> All
            {
                get { return context.Persons.OfType<Vendor>(); }
            }
            public IQueryable<Vendor> AllIncluding(params Expression<Func<Vendor, object>>[] includeProperties)
            {
                IQueryable<Vendor> query = context.Persons.OfType<Vendor>();
                foreach (var includeProperty in includeProperties) {
                    query = query.Include(includeProperty);
                }
                return query;
            }
            public Vendor Find(int id)
            {
                return context.Persons.OfType<Vendor>().SingleOrDefault(v => v.PersonID == id);
            }
            public void InsertOrUpdate(Vendor vendor)
            {
                if (vendor.PersonID == default(int)) {
                    // New entity
                    context.Persons.Add(vendor);
                } else {
                    // Existing entity
                    context.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                }
            }
            public void Delete(int id)
            {
                var vendor = context.Persons.OfType<Vendor>().SingleOrDefault(v => v.PersonID == id);
                context.Persons.Remove(vendor);
            }
            public void Save()
            {
                context.SaveChanges();
            }
            public void Dispose() 
            {
                context.Dispose();
            }
        }
