    public ActionResult ProtocolAjaxHandler(JQueryDataTableParamModel param)
            {
                var ar = db.ApplicantsRecords.ToList();
                if (ar == null)
                    return Json(new
                    {
                        data = new List<string>()
                    },
                    JsonRequestBehavior.AllowGet);
                return Json(new
                {
                    aaData = from emp in riski
                             select new[] { emp.col1, emp.col2 }
     
                },
                JsonRequestBehavior.AllowGet);
     
            }
