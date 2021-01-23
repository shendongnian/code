    class RetData
    {
        public int status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
            var retData = (new JavaScriptSerializer()).Deserialize<RetData>(jsonStr);
            if (retData.data.IsJsonArray())
                foreach (var obj in retData.data.AsJsonArray())
                    if (obj.JsonPropertyAt("username") != null)
                        Console.WriteLine(obj.JsonPropertyAt("password"));
