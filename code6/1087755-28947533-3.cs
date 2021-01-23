    private class MockHttpContext : HttpContextBase {
        private readonly IPrincipal _user = new GenericPrincipal(
                 new GenericIdentity("someUser"), null /* roles */);
        public override IPrincipal User {
            get {
                return _user;
            }
            set {
                base.User = value;
            }
        }
    }
