    public class SubscriberAttribute : Attribute { }
    static class TestClass
    {
        [SubscriberAttribute]
        static void Method(object sender, EventArgs args)
        {
            Console.WriteLine("Method called as expected.");
        }
        static void Nonsubscribed(object sender, EventArgs args)
        {
            Console.WriteLine("Wrong method called!");
        }
    }
    class MethodSubscriber
    {
        [STAThread]
        public static void Main()
        {
            var ms = new MethodSubscriber();
            ms.SubscribeToEvent(typeof(MethodSubscriber).Assembly);
        }
        public event EventHandler TestEvent;
        void SubscribeToEvent(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                // Test for a static class
                if (type.IsSealed == false) continue;
                if (type.IsClass == false) continue;
                // Check each method for the attribute.
                foreach (var method in type.GetRuntimeMethods())
                {
                    // Make sure the method is static
                    if (method.IsStatic == false) continue;
                    // Test for presence of the attribute
                    var attribute = method.GetCustomAttribute<SubscriberAttribute>();
                    if (attribute == null)
                        continue;
                    var del = (EventHandler)method.CreateDelegate(typeof(EventHandler));
                    TestEvent += del;
                }
            }
            TestEvent(null, EventArgs.Empty);
        }
