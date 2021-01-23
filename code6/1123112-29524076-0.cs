    bool didItWork = myFirstList.Intersect(MySecondList, new MyEqualityComparer()).Any();
    // ...
    public class MyEqualityComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.SomeDate.Date == y.SomeDate.Date;
        }
        public int GetHashCode(MyObject x)
        {
            return x.SomeDate.Date.GetHashCode();
        }
    }
