            public class MyClass
        {
            public DateTime dfd { get; set; }
            public DateTime dtd { get; set; }
            public string soprtr { get; set; }
        }
        public ActionResult crbtmis(string submitbuttonoperator, DateTime fromdate, DateTime todate, string operatorname)
        {
            MyClass myClass = new MyClass()
            {
                dfd = fromdate;
                dtd = todate;
                soprtr = operatorname;
            };
            Session["myClass"] = myClass;
            if (Session["user"] != null && Session["user"].ToString() == "MISADMIN")
            {
                switch (submitbuttonoperator)
                {
                    case "Export":
                        return (ExportOprtrlist(fromdate, todate, operatorname));
                    case "Search":
                        return (SearchByOperator());
                    default:
                        return (View("LogOn"));
                }
            }
            else
            {
                return RedirectToAction("LogOn");
            }
        }
        public ActionResult LogOn()
        {
            if (Session["myClass"] != null)
            {
                MyClass myClass = (MyClass)Session["myClass"];
            }
            return View();
        }
