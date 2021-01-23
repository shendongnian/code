      string input = "CGI HOLDING CORP THK 2.15 0.01 0.47 -64.17 6.25 1.92 23.78";
      List<string> inputSplit = input.Split(' ').ToList();
      PE_Ratio = Convert.ToDecimal(inputSplit[inputSplit.Count-1]);
      FiftyTwoWeekLow = Convert.ToDecimal(inputSplit[inputSplit.Count - 2]);
      FiftyTwoWeekHigh = Convert.ToDecimal(inputSplit[inputSplit.Count - 3]);
      YTDChange = Convert.ToDecimal(inputSplit[inputSplit.Count - 4]);
      PercentChange = Convert.ToDecimal(inputSplit[inputSplit.Count - 5]);
      PriceChange = Convert.ToDecimal(inputSplit[inputSplit.Count - 6]);
      CurrentPrice = Convert.ToDecimal(inputSplit[inputSplit.Count - 7]);
      TickerSymbol = inputSplit[inputSplit.Count - 8];
      for (int i = 0; i < inputSplit.Count - 8; i++)
      {
        Company = Company + (inputSplit[i] + " ");
      }
      Company = Company.Trim();
