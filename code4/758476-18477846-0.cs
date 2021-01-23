    public class UniqueToken
    {
        public Guid Id { get; private set; }
        public MessengerToken Token { get; private set; }
        public UniqueToken(Guid id, MessengerToken token)
        {
            Id = id;
            Token = token;
        }
    }
