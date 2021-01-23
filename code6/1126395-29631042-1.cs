    class Program
    {
        static void Main(string[] args)
        {
            var sgc = new SomeGenericClass<string>("asdf");
            var sgc2 = new SomeGenericClass<int>(1);
            var sgc3 = new SomeNonGenericChild("asdf2");
            Console.ReadKey();
        }
    }
    public class SomeGenericClass<T>
    {
        public enum InitialisationMode
        {
            UseDefaultValues,
            DoOtherThings = 3
        }
        public SomeGenericClass(T blah, InitialisationMode initMode = InitialisationMode.UseDefaultValues)
        {
         
            Console.WriteLine(blah.GetType().Name + "; " + initMode);
        }
    }
    public class SomeNonGenericChild : SomeGenericClass<string>
    {
        public new enum InitialisationMode
        {
            UseDefaultValues,
            DoEvenMoreThings
        }
        public SomeNonGenericChild(string blah, InitialisationMode initMode= InitialisationMode.DoEvenMoreThings) : base(blah)
        {
            
            Console.WriteLine(blah.GetType().Name + "; " + initMode);
        }
    }
