    public async Task<ActionResult> Index()
    {
        UserProfile[] profiles = await Checksomething();
        if (profiles.Any())
        {
              var user = profiles.First();
              string username = user.FirstName;
              // do something w/ username
        }
        return View();
    }
    public async Task<UserProfile[]> Checksomething()
    {
        try
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new UserLogin { EmailAddress = "SomeEmail@Hotmail.com", Password = "bahblah" }));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://localhost:28247/api/UserLoginApi2/CheckCredentials", content);
            var value = await response.Content.ReadAsStringAsync();
            // I need to return UserProfile
            return JsonConvert.DeserializeObject<UserProfile[]>(value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
