    private void Foo()
    {
        Uri StudentUri = new Uri("uri");
        WebRequest request = WebRequest.Create(StudentUri);
         
        Task<string> getContentTask = request.GetContentAsync();
        getContentTask.ContinueWith(t =>
        {
            string content = t.Result;
            // do whatever you want with downloaded contents
            // you may save to isolated storage
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            storage.WriteAllText("Student.xml", content);
            // you may read it!
            string readContent = storage.ReadAllText("Student.xml");
            var parsedEntity = YourParsingMethod(readContent);
        });
        // I'm doing my job
        // in parallel
    }
