    public JsonResult testList()
    {
        List<string> test = new List<string>;
        test.Add("test1");
        test.Add("test2");
        return Json(test,JsonRequestBehavior.AllowGet);
    }
