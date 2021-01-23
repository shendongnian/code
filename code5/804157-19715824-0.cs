    void Main()
    {
    	var test = new Test();
    	Console.WriteLine (test.X);
    	Console.WriteLine (test.Y);
    }
    
    public class Test {
     public int X {get; set;}
     public int Y {get; set;}
     
     public Test(){
      foreach(var prop in this.GetType().GetProperties()){
       if(prop.PropertyType == typeof(int)){
        prop.SetValue(this, -1);
       }
      }
     }
    }
