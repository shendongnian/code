     // GET: /dept/
        public string  Index()
        {
            IView myView;
            string result;
            using (var ctx = new ApplicationDbContext())
            {
                //my model brough using the dbContext
                IEnumerable<department> d = ctx.departments;
                // now because I want to render the View here [forcibly] and not waiting
                //for the normal MVC pipeline to render my View I had to jump to the ViewEngine
                //and ask it to render my View [while i am still inside this using statement]
                // so referring to the excellent article on :http://www.codemag.com/Article/1312081
                //I did the following:
                ControllerContext.Controller.ViewData.Model = d;
                ViewEngineResult viewEngResult = ViewEngines.Engines.FindView(ControllerContext, "~/Views/dept/Index.cshtml", null);
               
                myView = viewEngResult.View;
                //till this point the View is not rendered yet
                StringWriter tw = new StringWriter();// used to render the View into string
                ViewContext vc = new ViewContext(ControllerContext, myView, ControllerContext.Controller.ViewData, ControllerContext.Controller.TempData, tw);
                //it is the following method .Render(viewContext, textWriter) that will start iterating on the IEnumerable<department> object
                myView.Render(vc, tw);
                result = tw.ToString();// the rendered View is now written as string to the result
                tw.Dispose();
            }
            
            return result;
        }
	}
