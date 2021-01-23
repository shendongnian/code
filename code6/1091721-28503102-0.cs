    public class Foo
    {
        public event EventHandler MyEvent;
    }
    public class Bar
    {
        public static event EventHandler MyStaticEvent;
    }
    public class Test
    {
        public void MyDelegate(object sender, EventArgs e) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo aFoo = new Foo();
            Test aTest = new Test();
            aFoo.MyEvent += aTest.MyDelegate;
            FieldInfo subscribersReflect = typeof(Foo).GetField("MyEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            Delegate[] subscribers = (subscribersReflect.GetValue(aFoo) as MulticastDelegate).GetInvocationList();
            foreach (var sub in subscribers)
                Console.WriteLine(sub.Method.Name); // MyDelegate
            Bar.MyStaticEvent += aTest.MyDelegate;
            subscribersReflect = typeof(Bar).GetField("MyStaticEvent", BindingFlags.NonPublic | BindingFlags.Static);
            subscribers = (subscribersReflect.GetValue(null) as MulticastDelegate).GetInvocationList();
            foreach (var sub in subscribers)
                Console.WriteLine(sub.Method.Name); // MyDelegate
            
            Console.ReadLine();
        }
    }
