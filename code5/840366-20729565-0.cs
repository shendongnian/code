    static void Main(string[] args) 
    { 
        HttpClient client = new HttpClient(); 
        client.GetAsync(_address).ContinueWith( 
            (requestTask) => 
            { 
                HttpResponseMessage response = requestTask.Result; 
                response.EnsureSuccessStatusCode(); 
                response.Content.ReadAsAsync<JsonArray>().ContinueWith( 
                    (readTask) => 
                    { 
                        Console.WriteLine(
                         "First 50 countries listed by The World Bank..."); 
                        foreach (var country in readTask.Result[1]) 
                        { 
                            Console.WriteLine("   {0}, Country Code: {1}, " +
                                "Capital: {2}, Latitude: {3}, Longitude: {4}", 
                                country.Value["name"], 
                                country.Value["iso2Code"], 
                                country.Value["capitalCity"], 
                                country.Value["latitude"], 
                                country.Value["longitude"]); 
                        } 
                    }); 
            }); 
        Console.WriteLine("Hit ENTER to exit..."); 
        Console.ReadLine(); 
    }
