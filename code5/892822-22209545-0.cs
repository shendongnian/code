         List<PizzaOrder> orders = new List<PizzaOrder>(); // in summary class 
         // in onclick handler for Calc total
         orders.Add(newInstance);
         // in the display part of summary class
         int totalCokes = orders.Aggregate((c, n) => c.numberOfCokes + n.numberOfCokes);
         int cokeRevenue = totalCokes * PriceOfACoke;
          //ect
