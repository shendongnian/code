            List<Job> model = null;
            var client = new HttpClient();
            var task = client.GetAsync("http://api.usa.gov/jobs/search.json?query=nursing+jobs")
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  model = JsonConvert.DeserializeObject<List<Job>>(jsonString.Result);
                 
              });
            task.Wait();
            
