        public currencyData SendCurrencyQuery()
        {
            //make call to the API and retrieve JSON data
            char[] array2 = { };
            using (var client2 = new System.Net.WebClient())
            {
                client2.Headers.Add("item-data", "application/json");
                //get the JSON data.
                string currencyJSON = Encoding.UTF8.GetString(client2.UploadData("http://backpack.tf/api/IGetPrices/v4/?key=54972a10b88d885f748b4956&appid=440&compress=1", "POST", Encoding.UTF8.GetBytes(array2)));
                //same as above but store itt in currencyData.cs
                var currencyData = JsonConvert.DeserializeObject<currencyData>(currencyJSON);
                return currencyData;
            }
        }
 
