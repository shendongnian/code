    private static void GetPerson()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage authRequest = new HttpRequestMessage();
            authRequest.Method = HttpMethod.Post;
            authRequest.RequestUri = new Uri(@"http://localhost:4391/Account/Login");
            authRequest.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password)
                });
            HttpResponseMessage authResponse = httpClient.SendAsync(authRequest).Result;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, @"http://localhost:4391/api/Person/1");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Username or password is incorrect");
                return;
            }
            response.Content.ReadAsAsync<Person>().ContinueWith((x) => {
                    Person person = x.Result;
                    Console.WriteLine("First name: {0}", person.FirstName);
                    Console.WriteLine("Last name: {0}", person.LastName);
                });
        }
