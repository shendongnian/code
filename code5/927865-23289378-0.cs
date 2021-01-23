    int count = 0;
        int total = result.ForecastResult.Length;
        foreach (var rs in result.ForecastResult){
          if (count > 0)
          {
            Console.WriteLine("************************");
          }
          Console.WriteLine("Date:" + rs.Date);
          Console.WriteLine("Forecast:" + rs.Desciption);
          Console.WriteLine("Temperatures:");
          Console.WriteLine("Morning low - " + rs.Temperatures.MorningLow);
          Console.WriteLine("Daytime high - " + rs.Temperatures.DaytimeHigh);
          count++;
        }
        Console.WriteLine("------------------------------------------------------------------");
        Console.Write("ENTER to continue:");
        Console.ReadLine();
