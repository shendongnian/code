        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!externalUser.IsSecurityQuestionInfoComplete)
            {
                var routeData = new RouteData();
                routeData.Values["action"] = "MyInfo";
                routeData.Values["controller"] = "ChangeSecurityQuestions";
                RequestContext requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);
                IController errorController = new ChangeSecurityQuestionsController();
                errorController.Execute(requestContext);
                requestContext.HttpContext.Response.End();
            }
        }
