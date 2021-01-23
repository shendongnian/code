        public ActionResult Distributor(string method)
        {
            switch (method)
            {
                case "MyMethod1":
                    return MyMethod1();
                case "MyMethod2":
                    return MyMethod2();
                default:
                    return new HttpNotFoundResult();
            }
        }
