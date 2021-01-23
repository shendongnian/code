    using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            int systemId = 24;
            int id = 45;
            string queryString = "SystemId="+systemId+"&Id="+id;
            var response = client.PostAsJsonAsync("api/method/",queryString).Result;
            if (response.IsSuccessStatusCode)
            {
                // Do
            }
            else
                // DO
        }
