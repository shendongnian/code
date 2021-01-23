    public class LicenseHandler
    {
        private readonly Func<GroupLicense, User, bool> predicate;
        private readonly Action action;
        private LicenseHandler nextHandler;
        public LicenseHandler(Func<GroupLicense,User, bool> predicate, Action action)
        {
            this.action = action;
            this.predicate = predicate;
        }
        public LicenseHandler SetNext(LicenseHandler handler)
        {
            nextHandler = handler;
            return this;
        }
        public void Handle(GroupLicense license, User user)
        {
            if (predicate(license, user))
            {
                action();
                return;
            }
            if (nextHandler != null)
                nextHandler.Handle(license, user);
        }
    }
