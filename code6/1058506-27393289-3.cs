            this.repo = repo;
        }
        // In your repository:
        public MyRepository(Entities context)
        {
            this.context = context;
        }
        // In your entities:
        public Entities(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }
