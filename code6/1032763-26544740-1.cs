         public class HomeCustomBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                string title = request.Form.Get("Title");
                string day = request.Form.Get("Day");
                string month = request.Form.Get("Month");
                string year = request.Form.Get("Year");
                return new HomePageModels
                {
                    Title = title,
                    Date = day + "/" + month + "/" + year
                };
            }
            public class HomePageModels {
                public string Title { get; set; }
                public string Date { get; set; }
            
            }
        }
