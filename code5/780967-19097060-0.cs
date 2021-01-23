        public class MyEqualityComparer : IEqualityComparer<XElement>
        {
            public bool Equals(XElement x, XElement y)
            {
                return x.Name == y.Name;
            }
            public int GetHashCode(XElement obj)
            {
                return obj.Name.GetHashCode();
            }
        }
