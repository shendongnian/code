        private static Task<MyOutputObject> MyClientCall(string baseAddress, MyInputObject args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
			   /* Your class name would be "MyEntityController" most likely */
            string serviceUrl = baseAddress + @"api/MyEntity/DoSomething";
            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, args).Result;
            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("ERROR:  :(   " + response.ReasonPhrase);
                return null;
            }
            Task<MyOutputObject> wrap = response.Content.ReadAsAsync<MyOutputObject>();
            return wrap;
        }
