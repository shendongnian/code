    public interface MyInterface
    {
        void func1();
    }
    public class B : MyInterface
    {
        public func1() {...}
        ....
    }
    public class C : MyInterface
    {
        public void func1() {...}
        ....
    }
    //example of calling func1()
    List<A> list = new List<A>(stuff);
    foreach(A item in list)
    {
        MyInterface tmp = item as MyInterface;
        if(tmp != null)
        {
            tmp.func1();
        }
    }
