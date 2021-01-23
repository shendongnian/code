    using (var admin = Resolve<AdminServices>())
    {
        //...
        var dir = new FileSystemVirtualPathProvider(this, Config.WebHostPhysicalPath);
        var files = dir.GetAllMatchingFiles("*.txt")
            .Concat(dir.GetAllMatchingFiles("*.zip"));
    
        admin.Request = new BasicRequest
        {
            Files = files.Map(x => new HttpFile {
                ContentLength = x.Length,
                ContentType = MimeTypes.GetMimeType(x.Name),
                FileName = x.Name,
                InputStream = x.OpenRead(),
            } as IHttpFile).ToArray()
        };
    
        if (admin.Request.Files.Length > 0)
        {
            admin.Post(new UploadTestResults
            {
                TestPlanId = 1,
                TestRunId = testRun.Id,
                CreateNewTestRuns = true,
            });
        }
    }
