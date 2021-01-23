    public abstract class DomainUser : IAggregateRoot
    {
        public Guid Id { get; set; }
        public AppUser IdentityUser { get; set; }
    }
