        public class AppIdentityDbContext : IdentityDbContext<AppUser>
        {
        public AppIdentityDbContext()
            : base("IdentityContext", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!
           
             *****[skipped some other code]*****
            // In order to support multiple user names 
            // I replaced unique index of UserNameIndex to non-unique
            modelBuilder
            .Entity<AppUser>()
            .Property(c => c.UserName)
            .HasColumnAnnotation(
                "Index", 
                new IndexAnnotation(
                new IndexAttribute("UserNameIndex")
                {
                    IsUnique = false
                }));
            modelBuilder
                .Entity<AppUser>()
                .Property(c => c.Email)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new[]
                    {
                        new IndexAttribute("EmailIndex") {IsUnique = true}
                    }));
        }
        /// <summary>
        ///     Override 'ValidateEntity' to support multiple users with the same name
        /// </summary>
        /// <param name="entityEntry"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
            IDictionary<object, object> items)
        {
            // call validate and check results 
            var result = base.ValidateEntity(entityEntry, items);
            if (result.ValidationErrors.Any(err => err.PropertyName.Equals("User")))
            {
                // Yes I know! Next code looks not good, because I rely on internal messages of Identity 2, but I should track here only error message instead of rewriting the whole IdentityDbContext
                var duplicateUserNameError = 
                    result.ValidationErrors
                    .FirstOrDefault(
                    err =>  
                        Regex.IsMatch(
                            err.ErrorMessage,
                            @"Name\s+(.+)is\s+already\s+taken",
                            RegexOptions.IgnoreCase));
                if (null != duplicateUserNameError)
                {
                    result.ValidationErrors.Remove(duplicateUserNameError);
                }
            }
            return result;
        }
        }
