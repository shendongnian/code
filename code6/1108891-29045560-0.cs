                    using (var client = new HttpClient())
                    {
                       
                        client.BaseAddress = new Uri("http://Ipaddress/mammo/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = await client.GetAsync("api/controllername");
                       
                            if (response.IsSuccessStatusCode)
                            {   
                               IList<something> data = await response.Content.ReadAsAsync<IList<something>>();
                            }
                   }
