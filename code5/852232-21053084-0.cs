    public void TestEF()
        {
            using (DbContext db = new ElFaktura.Data.CustomerEntities())
            {
                var expr = CreateQuery<Customer>("FirstName", "Lorentz");
                var result = db.Set<Customer>().Where(expr);
                Debug.Print(result.ToString());
            }
        }
        public Expression<Func<Customer, bool>> CreateQuery<T>(string field, string value)
        {
            var paramExpr = Expression.Parameter(typeof(T));
            var propExpr = Expression.Property(paramExpr, field);
            var equalsExpr = Expression.Equal(propExpr, Expression.Constant(value));
            return Expression.Lambda<Func<Customer,bool>>(equalsExpr, paramExpr);
        }
