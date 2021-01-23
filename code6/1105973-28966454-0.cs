            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]  
            public string VIEW_LOCATION()
            {
                using (QLTDEntities db = new QLTDEntities())
                {
                    List<LOCATIONPARAM> list = new List<LOCATIONPARAM>();
                    list = db.LOCATIONs.Select(e => new LOCATIONPARAM()
                    {
                        LOCATION_ID = e.LOCATION_ID,
                        LOCATION_NAME = e.LOCATION_NAME,
                        FLAG = e.FLAG
                    }).ToList();
                    return new JavaScriptSerializer().Serialize(list);
                }
            }
