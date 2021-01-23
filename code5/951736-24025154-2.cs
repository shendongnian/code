    public class RandomStringGenerator
    {
       private string[] data;  //Data holder
       private Random rng; //Not instantiated since we pass it in
    
       public RandomStringGenerator(string[] startData, Random rngToUse)
       {
           data = startData;
           rng = rngToUse;
       }
       ... //Same as before
    }
