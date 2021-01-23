        public static void GenericRemoveSet<T>(System.Data.Entity.DbSet<T> set) where T:class
        {
            try { foreach (var item in set) set.Remove(item); }
            catch { }   /* TODO: some DbContext members still throw errors */
        }
        public static void ClearGenericDbContext(DbContext context)
        {
            var removeMethod = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.GetMethod("GenericRemoveSet");
            foreach (var prop in context.GetType().GetProperties().Where(p => p.PropertyType.Name.StartsWith("DbSet")))
            {
                var typedRemove = removeMethod.MakeGenericMethod(prop.PropertyType.GetGenericArguments().First());
                typedRemove.Invoke(null, new object[]{prop.GetValue(context)});
            }
            context.SaveChanges();
        }
