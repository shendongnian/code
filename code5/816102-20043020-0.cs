    ViewResult vr = new System.Web.Mvc.ViewResult
        {
            ViewName = this.View, //<======/Test/Test.cshtml
            ViewData = new ViewDataDictionary(filterContext.Controller.ViewData)
                {
                    Model = // set the model
                }
        };
