    @model System.Web.Mvc.HandleErrorInfo
    @{
	    ViewBag.Title = (!String.IsNullOrEmpty(ViewBag.StatusCode)) ? ViewBag.StatusCode : "500 Error";
    }
     <h1 class="error">@(!String.IsNullOrEmpty(ViewBag.StatusCode) ? ViewBag.StatusCode : "500 Error"):</h1>
    //@Model.ActionName
    //@Model.ContollerName
    //@Model.Exception.Message
    //@Model.Exception.StackTrace
