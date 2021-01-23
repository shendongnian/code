    private string BindDatatableTest()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer(); 
        string url = "http://wwww.test.domain.com/test2.aspx/BindDatatable";
        WebClient wc = new WebClient();        
        ServicePointManager.Expect100Continue = false;
        ServicePointManager.MaxServicePointIdleTime = 2000;
        string json = wc.DownloadString(url);
        object jsonData = new
        {
              jsonFinal = jsonD
        };
    
        return Content(serializer.Serialize(jsonData), "application/json");
    }
