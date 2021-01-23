         private HBIdentity _identity;
         public HBPrincipal(HBIdentity identity)
        {
            _identity = identity;
        }
        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }
        public bool IsInRole(string role)
        {
            // TODO implement roles
            return false;
        }
    }
