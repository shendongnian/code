    public void mood()
    {
      var unhappiness = Hunger + Boredom;
      string m = "Unknown";
              
      if (unhappiness < 5)
      {
        m = "Happy";
      }    
      else if (unhappiness >= 5 && unhappiness <= 10) // >= 5 not <= 5
      {
        m = "Okay";
      }
      else if (unhappiness > 11 && unhappiness <= 15) // > 10 or >= 11 not <= 11
      {
        m = "Frustrated";
      }
      else if (unhappiness >= 16) // assume it should be enything else
      {
        m = "Mad";
      }
    
      Console.WriteLine(m);
    }
