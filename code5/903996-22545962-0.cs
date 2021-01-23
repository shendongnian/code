    public class BaseC<T>
    {
       //...
       virtual List<T> Recs { get; set; }
    }
    public class Derived1 : Base<MyClassA>
    {
        override List<MyClassA> Recs { get; set; }
    }
