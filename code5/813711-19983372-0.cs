    private class DummyPrincipal : IPrincipal, IIdentity {
      public IIdentity Identity {
        get { return this; }
      }
      public bool IsInRole(string role) {
        return true;
      }
      public string AuthenticationType {
        get { return "DummyAuthenticationType"; }
      }
      public bool IsAuthenticated {
        get { return true; }
      }
      public string Name {
        get { return "TestUser"; }
      }
    }
