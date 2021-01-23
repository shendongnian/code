            Customer_List send= new Customer_List
            {
                phone= "***"
            };
            //
            string json = JsonConvert.SerializeObject(send);  
            //
            var client = new RestClient("http://localhost:1959/***");
            var request = new RestRequest();
            //
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", json, 
            ParameterType.RequestBody);
            //
            var response = client.Execute(request);
            var content = response.Content;
