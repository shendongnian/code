        public class MyController : Controller
        {
            [HttpPost]
            public ActionResult DoSomething(int inputValue)
            {
                var userName = User.UserName();
                return Json(new {
                    redirectUrl = Url.Action("RedirectAction", "RedirectController"),
                    isRedirect = true,
                });
            }  
        }
        [Test]
        public void Test1()
        {
            var sb = new StringBuilder();
            
            var response = Substitute.For<HttpResponseBase>();
            
            response.When(x => x.Write(Arg.Any<string>())).Do(ctx => sb.Append(ctx.Arg<string>()));
            var httpContext = Substitute.For<HttpContextBase>();
            
            httpContext.Response.Returns(response);
            httpContext.User.Identity.Name.Returns("TestUser");
            var controller = new MyController();
            controller.ControllerContext = new ControllerContext(httpContext, new RouteData(), myController);
            controller.Url = Substitute.For<UrlHelper>();
            controller.Url.Action(Arg.Any<string>(), Arg.Any<string>()).Returns("anything");
            controller.DoSomething(1);
        }
