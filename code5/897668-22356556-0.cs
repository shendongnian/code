     /// <summary>
        /// Class RoleAuthorizeAttribute.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
        public class RoleAuthorizeAttribute : AuthorizeAttribute
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RoleAuthorizeAttribute"/> class.
            /// </summary>
            /// <param name="roles">The roles.</param>
            /// <exception cref="System.ArgumentException">The roles parameter may only contain enums;roles</exception>
            public RoleAuthorizeAttribute(params object[] roles)
            {
                if (roles.Any(r => r.GetType().BaseType != typeof (Enum)))
                {
                    throw new ArgumentException(
                        "The roles parameter may only contain enums",
                        "roles");
                }
                Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)).ToList());
            }
        }
