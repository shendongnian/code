    public ActionResult GetTabData(string activeTab)
        {
            string viewName = String.Empty;
            switch (activeTab)
            {
                case "all":
                    viewName = "_AllPartial";
                    break;
                case "one":
                    viewName = "_OnePartial";
                    break;
                case "two":
                    viewName = "_TwoPartial";
                default:
                    viewName = "_AllPartial";      
                    break;                    
            }               
            return PartialView(string.concat("~/Views/Home/", viewName, ".cshtml");   
        }
