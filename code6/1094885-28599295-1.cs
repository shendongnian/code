        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(HomePageModels))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                string title = request.Form.Get("Title");
                string day = request.Form.Get("Day");
                string month = request.Form.Get("Month");
                string year = request.Form.Get("Year");
                if(User.IsInRole("Admin"))
                {
                string SSN = request.Form.Get("SSN");
                }
                return new HomePageModels
                {
                    Title = title,
                    Date = day + "/" + month + "/" + year,
                    SSN = SSN
                };
                //// real time HomePageModels instance should be loaded from database here to avoid saving null if person is not authorized to do so 
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
