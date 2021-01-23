    static void Main(string[] args)
    {
        var url = System.Configuration.ConfigurationManager.AppSettings["CentrisURL"];
        if (url == null)
        {
            Console.WriteLine("Failed to load API url");
        }
        var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        await Task.WhenAll(
            new Task[] {
                DbRequestHandler.ReadRooms(client),
                DbRequestHandler.ReadRoomsType(client),
                DbRequestHandler.ReadCourses(client),
                DbRequestHandler.ReadTeachers(client),
            }
        );
    }
