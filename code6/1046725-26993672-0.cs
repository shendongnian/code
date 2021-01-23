    class BaseClass { public void M() { Console.WriteLine("BaseClass"); } }
    class SubClass { public new void M() { Console.WriteLine("SubClass"); } }
   
    void Main() {
        var x = new SubClass();
        x.M(); // Prints "SubClass"
        ((BaseClass)x).M(); // Prints "BaseClass"
    }
