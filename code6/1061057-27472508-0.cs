    namespace TDAmeritrade.Samples
    {
        using System;
        using TDAmeritrade;
    
        class Program
        {
    		const string SaveFileToLocation = @"C:\Users\jessica\Desktop\json_data";
    		
            static void Main()
            {
                // find best place for these codes.
           		string json = JsonConvert.SerializeObject(prices, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(SaveFileToLocation))
    		    {
    			    writer.Write(json);   
    		    }
                // Initialize TD Ameritrade client, provide additional config info if needed
                var client = new TDAClient();
    
                // Log in to the TD Ameritrade website with your user ID and password
                client.LogIn("jessicasusername", "jessicaspassword");
    
                // Now 'client.User' property contains all the information about currently logged in user
                var accountName = client.User.Account.DisplayName;
    
                // Get stock quotes snapshot.
                var quotes = client.GetQuotes("GOOG, AAPL, $SPX.X, DUMMY");
    
                // 'quotes.Error' contains a list of symbols which have not been found
                var errors = quotes.Errors;
    
                // Find symbols matching the search string
                var symbols = client.FindSymbols("GOO");
    
                // Get historical prices
                var prices = client.GetHistoricalPrices("GOOG, AAPL", StartDate: DateTime.Today.AddDays(-7), EndDate: DateTime.Today.AddDays(-1));
            }
        }
    }
