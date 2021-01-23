    public class FooComparer : IEqualityComparer<Foo> 
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.Id == y.Id && x.someKey != y.someKey;
        }
        public int GetHashCode(Foo x)
        {
            return x.Id.GetHashCode();
        }
    }
    ...
    var comparer = new FooComparer();
    List<Foo> listOne = service.GetListOne();
    List<Foo> listTwo = service.GetListTwo();
    List<Foo> result = listOne.Intersect(listTwo, comparer).ToList();
