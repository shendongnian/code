    public class MyClassComparer : IComparer<MyClass>
    {
    	public int Compare(MyClass _x, MyClass _y)
    	{
    		return _x.MyProp.CompareTo(_y.MyProp);
    	}
    }
