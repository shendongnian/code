    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Gunaatita.ViewModel;
    namespace Gunaatita.Controllers
    {
        [HandleError]
        public class ErrorController : Controller
        {
            public ActionResult Error()
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.Message = "An Error Has Occured";
                errorInfo.Description = "An unexpected error occured on our website. The website administrator has been notified.";
                return PartialView(errorInfo);
            }
            public ActionResult BadRequest()
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.Message = "Bad Request";
                errorInfo.Description = "The request cannot be fulfilled due to bad syntax.";
                return PartialView("Error", errorInfo);
            }
            public ActionResult NotFound()
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.Message = "We are sorry, the page you requested cannot be found.";
                errorInfo.Description = "The URL may be misspelled or the page you're looking for is no longer available.";
                return PartialView("Error", errorInfo);
            }
            public ActionResult URLTooLong()
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.Message = "URL Too Long";
                errorInfo.Description = "The requested URL is too large to process. That’s all we know.";
                return PartialView("Error", errorInfo);
            }
            public ActionResult ServiceUnavailable()
            {
                ErrorInfo errorInfo = new ErrorInfo();
                errorInfo.Message = "Service Unavailable";
                errorInfo.Description = "Our apologies for the temporary inconvenience. This is due to overloading or maintenance of the server.";
                return PartialView("Error", errorInfo);
            }
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
            }
        }
    }
