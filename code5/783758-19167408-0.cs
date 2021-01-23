    [HttpPost]
    Public ActionResult Index(SearchModel sm)
    {
            List<Object> returnData = new List<Object>();
            returnData.Add(new { id = 1, cell = new string[] {"Id1","Votes1","Title1"} });
            returnData.Add(new { id = 2, cell = new string[] {"Id2","Votes2","Title2"} });
            returnData.Add(new { id = 3, cell = new string[] {"Id3","Votes3","Title3"} });
            var result = new { total = 1, page = 1, records = 3, rows = returnData };
            return Json(result, JsonRequestBehavior.AllowGet);
    }    
