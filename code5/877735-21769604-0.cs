        public class AjaxResponse
        {
                public AjaxResponse(bool success, object data)
                {
                    this.success = success;
                    this.data = data;
                }
                public bool success { get; set; }
                public object data { get; set; }
        }
        [HttpPost]
        public ActionResult Ajax()
        {
            return Json(new AjaxResponse(true, new { num = 5 }));
        }
