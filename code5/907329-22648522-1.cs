    string json; 
    using(FileStream fs = new FileStream(Server.MapPath("~/Content/treatments.json"), FileMode.Open))
    {
        using(StreamReader sr = new StreamReader(fs))
        {
            json = sr.ReadToEnd();
        }
    }
    JsonConvert.DeserializeObject<List<Treatment>>(json);
