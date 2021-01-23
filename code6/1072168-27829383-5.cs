        public ActionResult SubmitMyData(MyParamModel myParam)
        {
            // Do my stuff here with my parameter
            return View();
        }
        
        public class MyParamModel // #4
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }
