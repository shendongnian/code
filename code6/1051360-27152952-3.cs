    public object Post(UploadTestResults request)
    {
        //...
        foreach (var httpFile in base.Request.Files)
        {
            if (httpFile.FileName.ToLower().EndsWith(".zip"))
            {
                using (var zip = ZipFile.Read(httpFile.InputStream))
                {
                    var zipResults = new List<TestResult>();
                    foreach (var zipEntry in zip)
                    {
                        using (var ms = new MemoryStream())
                        {
                            zipEntry.Extract(ms);
                            var bytes = ms.ToArray();
    
                            var result = new MemoryStream(bytes).ToTestResult();
                            zipResults.Add(result);
                        }
                    }
                    newResults.AddRange(zipResults);
                }
            }
            else
            {
                var result = httpFile.InputStream.ToTestResult();
                newResults.Add(result);
            }
        }
    }
