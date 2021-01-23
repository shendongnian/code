    public interface InterfaceB 
    {
        int method(int d);
    }
    public class ClassB:InterfaceB
    {
        int a = 10;
        public int method(int d)
        {
            return a + d;
        }
    }
    var b = new ClassB();
    var mi = typeof(ClassB).GetInterface("InterfaceB").GetMethod("method");
    var res = mi.Invoke(b, new object[] { 10 }); // res == 20
