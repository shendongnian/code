    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRole"/> class.
        /// </summary>
        public CustomRole() { }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRole"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CustomRole(string name) { Name = name; }
    }
