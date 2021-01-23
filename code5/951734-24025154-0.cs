    public class RandomArray
    {
       private string[] data;  //Data holder
       private Random rng = new Random(); //Class level so it seeds once
    
       public RandomArray(string[] startData)
       {
           data = startData;
       }
    
       public string GetNextElement()
       {
           return data[rng.Next(0, data.Length)];
       }
    }
