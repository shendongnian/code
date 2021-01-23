    string passDotJsonAsJson = null;
    using(Stream pkpassAsStream = await client.GetPkpass())
    {
        responseStream.Position = 0;
        using(ZipFile pkpass = new ZipFile(pkpassAsStream))
        {
            var passDotJson = pkpass.GetEntry("pass.json");
                    
            using (var passDotJsonAsStream = pkpass.GetInputStream(passDotJson)) 
            {
                var reader = new StreamReader(passDotJsonAsStream);
                passDotJsonAsJson = await reader.ReadToEndAsync();
            }
        }
    }
