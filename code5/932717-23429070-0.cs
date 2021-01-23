    var context = new System.Web.Fakes.ShimHttpContext();
    var user = new StubIPrincipal
    {
    	IdentityGet = () =>
    	{
    		var identity = new StubIIdentity {NameGet = () => "foo"};
    		return identity;
    	}
    };
    context.UserGet = () => principal;
    System.Web.Fakes.ShimHttpContext.CurrentGet = () => { return context; };
