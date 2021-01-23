        [HttpPost]
        public JsonResult ExcelResults(ReportRequest tpRequest) {
            StringBuilder sb = new StringBuilder();
            bool firstIn = true;
            sb.AppendFormat("{0}/Home/ExcelRpt", Request.Url.Scheme + "://" + Request.Url.Authority);
            foreach (var prop in tpRequest.GetType().GetProperties()) {
                if (prop.GetValue(tpRequest, null) != null) {
                    if (firstIn) {
                        sb.AppendFormat("?");
                        firstIn = false;
                    } else {
                        sb.AppendFormat("&");
                    }
                    sb.AppendFormat("{0}={1}", prop.Name, prop.GetValue(tpRequest, null));
                }
            }
            return Json(new { URL = sb.ToString() }); 
        }
