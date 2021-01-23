    public class WidgetRepository
    {
        private UserContext User { get; set; }
        public WidgetRepository(UserContext user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            // maybe also confirm that it's a *valid* user in some way?
            User = user;
        }
        // repository operations
    }
