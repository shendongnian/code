    [WebMethod]
    public List<PersonData> GetInfo(List<byte[]> images)
    {
        var result = new ConcurrentBag<PersonData>();
    
        Parallel.ForEach(images, image => {
            result.Add(GetInfo(image));
        });
    
        return result.ToList();
    }
