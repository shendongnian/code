    public virtual string ToJson()
    {
        string json = null;
        using (MemoryStream ms = new MemoryStream())
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            ser.WriteObject(ms, this);
            json = Encoding.UTF8.GetString(ms.ToArray());
        }
        return json;
    }
