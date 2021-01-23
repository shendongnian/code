    public class Base {}
    public class Derived : Base
    {
        public void DoStuff()
        {
            Console.WriteLine("Doing stuff!");
        }
    }
    ...
    public static void Main(string[] args)
    {
        Derived myDerivedObject = new Derived();        
        Base myObjectAsBase = myDerivedObject; // This is fine because Derived "is a" Base
        
        // call methods
        myDerivedObject.DoStuff();           // OK - 'Derived' has a 'DoStuff()' method
        myObjectAsBase.DoStuff();            // Compiler error - 'Base' does not have a 'DoStuff()' method
        ((Derived)myObjectAsBase).DoStuff(); // OK - myObjectAsBase is cast to type 'Derived' which has a 'DoStuff()' method
    }
