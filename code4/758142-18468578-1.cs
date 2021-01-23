    public class MyCustomObjectComparer : IEqualityComparer<INameAndQty>
    {
        bool Equals(INameAndQty x, INameAndQty y)
        {
            return x.Name.Equals(y.Name);
        }
        int GetHashCode(INameAndQty obj)
        {
            return obj.Name.GetHashCode();
        }
    }
