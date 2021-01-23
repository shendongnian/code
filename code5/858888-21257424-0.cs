    public static gta_allCustomersResponse gta_AllCustomers()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.somewhere.com/desk/external_api/v1/customers.json");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Basic reallylongstring");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                gta_allCustomersResponse answer =  JsonConvert.DeserializeObject<gta_allCustomersResponse>(streamReader.ReadToEnd());
                return answer;
            }
        }
