    private Dictionary<string, byte[]> Charts = new Dictionary<string, byte[]>();
    
    public string GetChart(string name)
    {
         get
         {
             string mimeType = "image/png";
             string base64 = Convert.ToBase64String(Charts[name]);
    
             return string.Format("data: {0}; base64, {1}", mimeType, base64);
         }
    }
    public string AddChart(string name, byte[] data)
    {
        Charts[name] = data;
    }
