    if (url == null)
            {
                Console.WriteLine("Failed to load API url");
            }
    
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
           Task[] taskArray = new Task[4];
           taskArray[0] = Task.Factory.StartNew(await DbRequestHandler.ReadRooms(client));
           taskArray[1] = Task.Factory.StartNew(DbRequestHandler.ReadRoomsType(client));
           taskArray[2] = Task.Factory.StartNew(DbRequestHandler.ReadCourses(client));
           taskArray[3] = Task.Factory.StartNew(DbRequestHandler.ReadTeachers(client));
           Task.WaitAll(taskArray);
