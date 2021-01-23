     string csv = "content here";
     var response = new HttpResponseMessage();
     response.Content = new StringContent(csv, Encoding.UTF8, "text/csv");
     response.Content.Headers.Add("Content-Disposition", 
                                  "attachment; 
                                  filename=yourname.csv");
     return response;
