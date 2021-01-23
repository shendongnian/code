    public class productionDetail 
    {
      public string ProductName {get;set;}
      public int ProductionQuantity {get;set;}
      public double ProductionPercentage  {get;set;}
      public productionDetail(string productName, int productQuantity)
      {
        ProductName = productName;
        ProductionQuantity = productQuantity;
        ProductionPercentage = 0; // This will change later on
      }
    }
    public class Production
    {
      public List<productionDetail> Details {get;set;}
      public int TotalProduction {get;set;}
      public production (List<productionDetail> myDetails)
      {
        Details = myDetails;
        RecalculatePercentage();
      }
      //Here the total will be calculated
      public void MakeTotal()
      {
        var totalProduction = 0;
        foreach(productionDetail d in Details )
        {
          totalProduction += d.ProductionQuantity;
        }
        TotalProduction = totalProduction;
      }
      public void RecalculatePercentage()
      {   
        MakeTotal();
        //Here you will update the detail records for the percentage.
        foreach(productionDetail d in Details )
        {
          d.ProductionPercentage = Convert.ToDouble(d.ProductionQuantity) / Convert.ToDouble(TotalProduction) * 100;
        }
      }
      public void AddDetail(productionDetail detail)
      {
        Details.Add(detail);
        RecalculatePercentage();
      }
    }
