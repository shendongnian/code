    /// <summary>
    /// Defines the custom membership provider class.
    /// </summary>
    public class SsoMembershipProvider : MembershipProvider
    {
        private IApplicationsRepository _appsRepo;
        private IUsersRepository _usersRepo;
        private IMembershipsRepository _membershipsRepo;
        /// <summary>
        /// Initializes a new instance of the <see cref="SsoMembershipProvider"/> class
        /// using injectionConstructor attribute in order to get the repositories needed.
        /// </summary>
        /// <param name="appsRepo">The apps repo.</param>
        /// <param name="usersRepo">The users repo.</param>
        /// <param name="membershipsRepo">The memberships repo.</param>
        [InjectionConstructor]
        public SsoMembershipProvider(IApplicationsRepository appsRepo, IUsersRepository usersRepo, IMembershipsRepository membershipsRepo)
        {
            _appsRepo = appsRepo;
            _usersRepo = usersRepo;
            _membershipsRepo = membershipsRepo;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SsoMembershipProvider"/> class.
        /// which calls the internal contructor.
        /// </summary>
        /// <remarks>This is happening due to the fact that membership provider needs a
        /// parametless constructor to be initialized</remarks>
        public SsoMembershipProvider()
            : this(DependencyResolver.Current.GetService<IApplicationsRepository>(),
            DependencyResolver.Current.GetService<IUsersRepository>(),
            DependencyResolver.Current.GetService<IMembershipsRepository>())
        { }
    }
