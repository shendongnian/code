    public static class Util
    {
         public int GetTotalCheeseburgerCount(List<Animal> animals)
         {
              var total = 0;
              
              foreach(var animal in animals)
              {
                   // not every animal can have cheeseburgers, so we 
                   // can ignore this animal if it can't.
                   var canHasCheeseburger = animal as ICanHasCheeseburger;
                   if (canHasCheeseburger != null)
                   {
                       if (canHasCheeseburger.Cheeseburgers != null)
                       {
                           total += canHasCheeseburger.Cheeseburgers.Count;
                       }
                   }
              }
              return total;
          }
     }
