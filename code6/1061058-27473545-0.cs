    using System;
    using TDAmeritrade;
    namespace TDAmeritrade.Samples
    {    
        class Program
        {
            const string SaveFileToLocation = @"C:\Users\jessica\Desktop\json_data";
            static void Main()
            {
                // Initialize TD Ameritrade client, provide additional config info if needed
                var client = new TDAClient();
                // Log in to the TD Ameritrade website with your user ID and password
                client.LogIn("jessicasusername", "jessicaspassword")
                // Get historical prices
                var prices = client.GetHistoricalPrices("GOOG, AAPL", StartDate: DateTime.Today.AddDays(-7), EndDate: DateTime.Today.AddDays(-1));
                
                //You cannot create json until the prices variable has been declared!
                string json = JsonConvert.SerializeObject(prices, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(SaveFileToLocation))
                {
                    writer.Write(json);   
                }
            }
        }
    }
