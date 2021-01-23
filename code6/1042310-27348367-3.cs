    using System;
    using Microsoft.AspNet.Identity.EntityFramework;
    /// <summary>
    /// The guid role.
    /// </summary>
    public class GuidRole : IdentityRole<Guid, GuidUserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidRole"/> class.
        /// </summary>
        public GuidRole()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidRole"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public GuidRole(string name)
            : this()
        {
            this.Name = name;
        }
    }
    public class GuidUserRole : IdentityUserRole<Guid> { }
    public class GuidUserClaim : IdentityUserClaim<Guid> { }
    public class GuidUserLogin : IdentityUserLogin<Guid> { }
    /// <summary>
    /// The user.
    /// </summary>
    public class User : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }
