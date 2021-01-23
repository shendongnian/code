    public class Taxi
    {
        public bool isInitialized;
        //This is the normal constructor, which is invoked upon creation.
        public Taxi()
        {
            //All the code in here will be called whenever a new class
            //is created.
            isInitialized = true;
        }
       //This is the static constructor, which is invoked before initializing any Taxi class
       static Taxi()
       {
           Console.WriteLine("Invoked static constructor");
       } 
    }
    class TestTaxi
    {
        static void Main()
        {
            Taxi t = new Taxi(); //Create a new Taxi, therefore call the normal constructor
            Console.WriteLine(t.isInitialized); 
        }
    }
    
    //Output:
    //Invoked static constructor
    //true
