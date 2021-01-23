    void Application_AuthenticateRequest(object sender, EventArgs e) {
      var collection = new ClaimsIdentityCollection();
      var identity = new ClaimsIdentity(new DummyIdentity());
      identity.Claims.Add(new Claim("EnterpriseID", "Whatever"));
      collection.Add(identity);
      var principal = new ClaimsPrincipal(collection);
      Context.User = principal;
    }
