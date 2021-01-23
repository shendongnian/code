    public string SerializeAsBase64()
    {
        var session = new SessionCredentials { SessionKey = Guid.NewGuid() };
        using (var mem = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(mem, session);
            var bytes = mem.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
