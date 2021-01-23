        public class TimeArrayComparer : IEqualityComparer<Time[]>
        {
            public bool Equals(Time[] x, Time[] y)
            {
                if (x == y) return true;
                if (x == null) return false;
                return GetHashCode(x) == GetHashCode(y);
            }
            public int GetHashCode(Time[] obj)
            {
                if(obj == null) throw new ArgumentNullException("obj");
                return obj.Aggregate(-1, (current, time) => current ^ (time.Start.GetHashCode() ^ time.End.GetHashCode()));
            }
        }
