    public class Machine
    {
      public string model {get; set;}
      public int hours {get; set;}
      public static int totalnum = 0;
      public int num;
    
      public Machine() // constructor
      {
        model = "Cat";
        hours = 0;
        num = totalnum;
        totalnum ++; // count how many times class initialized
      }
    
      public void display() // display method
      {
        Console.WriteLine("Machine #{0} Info: Model: {1}, Hours: {2}",
    	num, model, hours.ToString());
      }
    }
