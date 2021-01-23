         static async void DoSomethingAsync()
        {
            const string connectionString = "mongodb://localhost:27017";
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);
            //Use the MongoClient to access the server
            var database = client.GetDatabase("test");
            //get mongodb collection
            var collection = database.GetCollection<Entity>("entities");
            await collection.InsertOneAsync(new Entity { Name = "Jack" });
        }
