    public class Taxi
    {
        public bool isInitialized;
        //This is the constructor
        public Taxi()
        {
            //All the code in here will be called whenever a new class
            //is created.
            isInitialized = true;
        }
    }
    class TestTaxi
    {
        static void Main()
        {
            Taxi t = new Taxi(); //Create a new Taxi, therefore call the constructor
            Console.WriteLine(t.isInitialized); //Writes "true" on console.
        }
    }
