        //create our own AD Provider
        private System.Web.Security.ActiveDirectoryMembershipProvider base_provider;
        private bool initialised = false;
        //these values are saved when Init if first called by the Membership Collection. 
        //So that I can pass them back into the new base_provider when it is made.
        private string name = null;
        private System.Collections.Specialized.NameValueCollection config;
        private Exception init_exception;
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            this.name = name;
            this.config = config;
            try
            {
                base_provider = new System.Web.Security.ActiveDirectoryMembershipProvider();
                base_provider.Initialize(name, config);
                initialised = true;
            }
            catch (Exception e)
            {
                this.base_provider = null;
                init_exception = e;
            }
        }
        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            if (!initialised) this.Initialize(this.name, this.config);
            
            //just a custom exception that my Membership object (that handles calling the two providers) picks up on
            if (base_provider == null) throw new NotInitialisedException(this.init_exception.Message);
            return base_provider.GetAllUsers(pageIndex, pageSize, out totalRecords);
        }
        ....
