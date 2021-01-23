        public BaseApiController()
        {
            CurrentUser = new ScrubbedUser(User);
        }
        protected ScrubbedUser CurrentUser { get; set; }
