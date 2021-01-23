    public ActionResult hello()
    {
        dynamic d = new JObject();
        d.MetricId = 11;
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(d);
        return Content(json,"JSon");
    }
