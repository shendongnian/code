    class Base {}
    class Derived : Base {}
    class SomeOther : Base {}
    var list = new List<Derived>();
    var baseList = (IList<Base>)list;
	
    baseList.Add(new SomeOther()); // oops, add SomeOther to a List<Derived>
