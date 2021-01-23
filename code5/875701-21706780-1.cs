         public async Task<IEnumerable<Student>> GetStudents()
                {           
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
                            var response = await client.GetAsync("student").ConfigureAwait(false);
                            var statusCode = response.StatusCode; //HERE IT IS
                            return response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                        }    
       
            }
