    public class Calories
    {
      public List<decimal> Calories;
      public decimal Total{ get { return this.Calories.Sum(); } }
      
      public Calories()
      {
    	this.Calories = new List<decimal>();
      }
    }
