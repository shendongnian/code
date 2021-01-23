       [HttpPost]
            public ActionResult GetSelectedClientDetails(string ClientId)
            {
                ProgressNotesService objService = new ProgressNotesService();
                var Client_Detail = objService.GetSelectedClient(Convert.ToInt32(ClientId));
                if (Client_Detail != null)
                {
                    Session["Client_ID"] = Client_Detail.Id;
                }
                return Json(new { Info = Client_Detail });
            }
    
