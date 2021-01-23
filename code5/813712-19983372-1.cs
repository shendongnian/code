    private class DummyIdentity : IIdentity {
      public string AuthenticationType {
        get { return "Dummy"; }
      }
      public bool IsAuthenticated {
        get { return true; }
      }
      public string Name {
        get { return "DummyUser";  }
      }
    }    
