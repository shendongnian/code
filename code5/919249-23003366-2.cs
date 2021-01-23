    [HttpPost]
    public void POST(string text)
    {
        dynamic result = JsonConvert.DeserializeObject(text);
        foreach (var res in result)
        {
            var ele = new Test();
            ele.ArrayId = int.Parse(res.Name);
            dynamic value = res.Value;
            ele.FormId = int.Parse(value.FormId.Value);
            ele.Ip = value.UserIp.Value;
            //etc.
        }
    }
