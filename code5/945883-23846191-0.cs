    private decimal GetPrice(object size)
    {
          decimal thePrice = 0m;
          if ("Small".Equals(size))
          {
                thePrice = 1.25m;
          }
          else if ("Medium".Equals(size))
          {
                thePrice = 2.50m;
          }
          else if ("Large".Equals(size))
          {
                thePrice = 3.35m;
          }
          return thePrice;
    }
