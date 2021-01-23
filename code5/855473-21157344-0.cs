    private class IdComparer : IEqualityComparer<object>
        {
            public bool Equals(object x, object y)
            {
                return ((dynamic) x).Id = ((dynamic) y).Id;
            }
            public int GetHashCode(object obj)
            {
               return ((dynamic) obj).Id;
            }
        }
        private static void Copy(IEnumerable source, IEnumerable dest)
        {
            var cmp = new IdComparer();
            var toRemove = dest.Cast<object>().Except(source.Cast<object>(),cmp).ToList();
            var toAdd= source.Cast<object>().Except(dest.Cast<object>(),cmp).ToList();
            foreach(var item in toAdd)
            {
                ((dynamic) dest).Add(item);
            }
            foreach (var item in toRemove)
            {
                ((dynamic)dest).Remove(item);
            }
        }
