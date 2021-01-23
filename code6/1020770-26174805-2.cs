        public ActionResult Distributor(string method)
        {
            switch (method)
            {
                case "MyMethod1":
                    return MyMethod1(Request.QueryString["param1"]);
                case "MyMethod2":
                    return MyMethod2(Request.QueryString["param1"], Request.QueryString["param2"]);
                default:
                    return new HttpNotFoundResult();
            }
        }
