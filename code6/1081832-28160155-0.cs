    public ActionResult Test()
    {
        tests = new List<Test>
        {
            new Test {Key = "vKey1", Value = "value1"},
            new Test {Key = "vKey2", Value = "value2"}
        };
        var tests2 = new List<Dictionary<string, string>>();
        tests.ForEach(x => tests2.Add(new Dictionary<string, string>
        {
            { x.Key, x.Value }
        }));
        return Json(tests2, JsonRequestBehavior.AllowGet);
    }
