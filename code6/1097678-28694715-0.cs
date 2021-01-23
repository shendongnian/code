    var strJson = "[{\"PlayerName\":\"WA Mota\"},{\"PlayerName\":\"Atif Ahmed\"}]";
    var strJsonSer = new JavaScriptSerializer();
    var list = new List<string>();
    var result = strJsonSer.DeserializeObject(strJson) as object[];
    if (result != null)
    {
        foreach (Dictionary<string, object> x in result)
        {
            list.Add(x["PlayerName"].ToString());
        }
    }
