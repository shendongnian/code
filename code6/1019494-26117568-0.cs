    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var obj = new DerivedClass();
            // That is the same as:
            //DerivedClass obj = new DerivedClass();
            // Will call the base method, since that now matches the
            // signature (takes an int parameter). DerivedClass simply
            // does not HAVE a method with that signature on it's own:
            obj.SomeMethod(5); // will output "base with int"
            // Now call the other method, which IS defined in DerivedClass, 
            // by appending an "l", to mark this as a Long:
            obj.SomeMethod(5l); // Will output "derived"
            // This would call the base method directly
            var obj2 = new BaseClass();
            obj2.SomeMethod(5l); 
            
            Console.ReadKey();
        }
    }
    internal class BaseClass
    {
        internal void SomeMethod(int a)
        {
            Console.WriteLine("base with int");
        }
        // Added method for the example:
        // Note that "virtual" allows it to be overridden
        internal virtual void SomeMethod(long a)
        {
            Console.WriteLine("base with long");
        }
    }
    internal class DerivedClass : BaseClass
    {
        // Note: Overrides the base method now
        internal override void SomeMethod(long a)
        {
            Console.WriteLine("derived");
        }
    }
