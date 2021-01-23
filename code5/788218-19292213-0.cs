    protected void btnGetdata_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:xxxx/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string param = "AsOnDate=" + System.DateTime.Today + "&AccID=" + 90000 + "&BCRefCode=" + 100;
            HttpResponseMessage response = client.GetAsync("/api/account?" + param, HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                var aa = response.Content.ReadAsAsync<object>().Result;
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<YourClassName>>(aa.ToString());
            }
        }
