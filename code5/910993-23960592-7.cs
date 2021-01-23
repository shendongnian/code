    var claim = new Claim("test", "IdOfYourChoosing");
    var mockIdentity =
        Mock.Of<ClaimsIdentity>(ci => ci.FindFirst(It.IsAny<string>()) == claim);
    var controller = new MyController()
    {
        User = Mock.Of<IPrincipal>(ip => ip.Identity == mockIdentity)
    };
    controller.User.Identity.GetUserId(); //returns "IdOfYourChoosing"
