        public ActionResult SubmitMyData([FromBody] MyParamModel myParam)
        {
            // Do my stuff here with my parameter
            return View();
        }
        
        public class MyParamModel
        {
            string Prop1 { get; set; }
            string Prop2 { get; set; }
        }
