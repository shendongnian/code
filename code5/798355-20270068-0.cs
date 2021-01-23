    public class MyPersonEqualityComparer : IEqualityComparer<MyPerson>
    {
    public bool Equals(MyPerson x, MyPerson y)
    {
        if (object.ReferenceEquals(x, y)) return true;
        if (object.ReferenceEquals(x, null)||object.ReferenceEquals(y, null)) return false;
        return x.Name == y.Name && x.Age == y.Age;
    }
    public int GetHashCode(MyPerson obj)
    {
        if (object.ReferenceEquals(obj, null)) return 0;
        int hashCodeName = obj.Name == null ? 0 : obj.Name.GetHashCode();
        int hasCodeAge = obj.Age.GetHashCode();
        return hashCodeName ^ hasCodeAge;
    }
}
