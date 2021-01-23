    public class Calories
    {
      public List<decimal> Calories;
      public decimal Total;
      
      private void GetTotal()
      {
    	this.Total = this.Calories.Sum();
      }
    }
