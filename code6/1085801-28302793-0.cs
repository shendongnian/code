    static async Task RunAsync()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("localhost:8080/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   
                    // HTTP POST
                    var docViewModel = new DocRepoViewModel() { CategoryName = "Foo", Roles= "role1,role2" };
       		        var attachmentInfo = new List<AttachmentViewModel>() { AttachmentName = "Bar", AttachmentType = "Baz", AttachmentBytes = File.ReadAllBytes("c:\test.txt" };
                    response = await client.PostAsJsonAsync("DocRepoApi/PostDoc", docViewModel);
                    if (response.IsSuccessStatusCode)
                    {
                      // do stuff
                    }
                }
            }
