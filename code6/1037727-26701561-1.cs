    var ds = new DataContractJsonSerializer(typeof(Model));
    var model = new Model
        {
            ModelPoints = new[] { 
                new[] { 1f, 2f, 3f }, 
                new[] { 4f, 5f, 6f } }
        };
    var sb = string.Empty;
    using (var ms = new MemoryStream())
    {
        ds.WriteObject(ms, model);
        sb= Encoding.UTF8.GetString(ms.ToArray());
    }
    Debug.WriteLine(sb);
