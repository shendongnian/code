           public JsonResult GetData()
           {
            List<Dictionary<string, object>> resultRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> resultRow;
            resultRow = new Dictionary<string, object>();
                        resultRow.Add("column1", "value1");
                        resultRow.Add("column2", "value2");
                        //...add more
            resultRows.Add(resultRow);
            return Json(resultRows, JsonRequestBehavior.AllowGet);
             }
