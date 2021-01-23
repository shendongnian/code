    class Program
    {
        static void Main(string[] args)
        {
            var guids = Enumerable.Range(0, 10).Select(i => Guid.NewGuid()).ToList();
            var m2s = guids.Select(g => new Model2 { ID = g }).ToList();
            var model1 = new Model1 { Model2ID = m2s[4].ID };
            model1.LinkTo(m2s, (m1, m2) => m1.Model2 = m2, (m1, m2) => m2.ID == m1.Model2ID);
            var model1a = new Model1 { Model2ID = m2s[4].ID };
            model1a.LinkTo(m2s, m1 => m1.Model2, m1 => m1.Model2ID, m2 => m2.ID);
            var model1b = new Model1 { Model2ID = m2s[4].ID };
            model1b.LinkTo(m2s, m1 => m1.Model2, (m1, m2) => m1.Model2ID == m2.ID);
        }
    }
    public static class ObjectExtensions
    {
        public static void LinkTo<T, U>(this T m1, IEnumerable<U> m2s, Action<T, U> action, Func<T, U, bool> filter)
        {
            if (m2s.Any(m2 => filter(m1, m2)))
            {
                var x = m2s.First(m2 => filter(m1, m2));
                action(m1, x);
            }
        }
        public static void LinkTo<T, U>(this T m1, IEnumerable<U> m2s, Expression<Func<T, U>> propertyExpression, Func<T, U, bool> filter)
        {
            var results = m2s.Where(m2 => filter(m1, m2));
            if (!results.Any())
                return;
            var x = results.FirstOrDefault();
            if (x != null)
            {
                var me = (propertyExpression.Body as MemberExpression);
                if (me != null)
                {
                    var pi = me.Member as PropertyInfo;
                    if (pi != null)
                    {
                        var setter = pi.GetSetMethod();
                        if (setter != null)
                        {
                            setter.Invoke(m1, new object[] { x });
                        }
                    }
                }
            }
        }
        public static void LinkTo<T, U, Key>(this T m1, IEnumerable<U> m2s, Expression<Func<T, U>> propertyExpression, Func<T, Key> tKey, Func<U, Key> uKey)
        {
            var results = Enumerable.Repeat(m1, 1)
                .Join(m2s, tKey, uKey, (t, u) => u);
            if(!results.Any())
                return;
            var x = results
                .FirstOrDefault();
            if (x != null)
            {
                var me = (propertyExpression.Body as MemberExpression);
                if (me != null)
                {
                    var pi = me.Member as PropertyInfo;
                    if (pi != null)
                    {
                        var setter = pi.GetSetMethod();
                        if (setter != null)
                        {
                            setter.Invoke(m1, new object[] { x });
                        }
                    }
                }
            }
        }
    }
