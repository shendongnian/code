        public static Func<UserManager<DomainUser>> UserManagerFactory { get; set; }
        static Startup()
        {
            UserManagerFactory = () => new UserManager<DomainUser>(new UserStore<DomainUser>(new DomainModelContext()));
        }
