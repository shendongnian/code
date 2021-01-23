        public class AppUserValidator : IIdentityValidator<AppUser>
        {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public AppUserValidator(UserManager<AppUser> manager)
        {
            Manager = manager;
        }
         
        private UserManager<AppUser, string> Manager { get; set; }
        /// <summary>
        ///     Validates a user before saving
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var errors = new List<string>();
            ValidateUserName(item, errors);
            await ValidateEmailAsync(item, errors);
            
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }
        private void ValidateUserName(AppUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add("Name cannot be null or empty.");
            }
            else if (!Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                // If any characters are not letters or digits, its an illegal user name
                errors.Add(string.Format("User name {0} is invalid, can only contain letters or digits.", user.UserName));
            }
        }
        // make sure email is not empty, valid, and unique
        private async Task ValidateEmailAsync(AppUser user, List<string> errors)
        {
            var email = user.Email;
            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add(string.Format("{0} cannot be null or empty.", "Email"));
                return;
            }
            try
            {
                var m = new MailAddress(email);
            }
            catch (FormatException)
            {
                errors.Add(string.Format("Email '{0}' is invalid", email));
                return;
            }
            var owner = await Manager.FindByEmailAsync(email);
            if (owner != null && !owner.Id.Equals(user.Id))
            {
                errors.Add(string.Format(CultureInfo.CurrentCulture, "Email '{0}' is already taken.", email));
            }
        }
        }
        public class AppUserManager : UserManager<AppUser>
        {
        public AppUserManager(
            IUserStore<AppUser> store,
            IDataProtectionProvider dataProtectionProvider,
            IIdentityMessageService emailService)
            : base(store)
        {
           
            // Configure validation logic for usernames
            UserValidator = new AppUserValidator(this);
            
