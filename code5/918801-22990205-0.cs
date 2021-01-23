    public ActionResult Parse(string text)
    {
        Dictionary<int, List<int>> dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, List<int>>>(text);
        return Json(dictionary.ToString(), JsonRequestBehavior.AllowGet);
    }
