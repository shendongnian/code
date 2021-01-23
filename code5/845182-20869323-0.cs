    using System.Web.Mvc;
    public class MyCustomClass
    {
        private UrlHelper _urlHelper;
        public MyCustomClass(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public string GetThatURL()
        {         
          string url=_urlHelper.Action("Index", "Invoices"); 
          //do something with url or return it
          return url;
        }
    }
