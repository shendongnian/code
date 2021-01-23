    var context = new Mock<HttpContextBase>();
    context.Setup(c => c.Items).Returns(new Dictionary<object, object>());
    context.Setup(c => c.User.Identity.IsAuthenticated).Returns(false);
    var controller = new Mock<ControllerBase>();
    
    var actionDescriptor = new Mock<ActionDescriptor>();
    actionDescriptor.Setup(a => a.ActionName).Returns("Index");
    var controllerDescriptor = new Mock<ControllerDescriptor>();            
    actionDescriptor.Setup(a => a.ControllerDescriptor).Returns(controllerDescriptor.Object);
    
    var controllerContext = new ControllerContext(context.Object, new RouteData(), controller.Object);
    var filterContext = new AuthorizationContext(controllerContext, actionDescriptor.Object);
    var att = new ConfigurableAuthorizeAttribute();
    
    att.OnAuthorization(filterContext);
    
    Assert.That(filterContext.Result, Is.InstanceOf<RedirectResult>());
    Assert.That(((RedirectResult)filterContext.Result).Url, Is.EqualTo("~/home/Unauthorized"));
