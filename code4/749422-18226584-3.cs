    public string serverName2
    {
        get
        {
            return Encoding.ASCII.GetString(servername).TrimEnd('\0');
        }
    }
