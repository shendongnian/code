    var result = ListA.Except(ListB, new Comparer());
---
    public class Comparer : IEqualityComparer<Detail>
    {
        public bool Equals(Detail x, Detail y)
        {
            return x.Name == y.Name
                    && x.State == y.State
                    && x.City == y.City
                    && x.tran.SequenceEqual(y.tran);
        }
        public int GetHashCode(Detail obj)
        {
            return obj.Name.GetHashCode();
        }
    }
