    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Claims;
    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(ClaimsPrincipal principal)
            : base(principal.Identities)
        {
        }
        public int UserId
        {
            get { return FindFirstValue<int>(ClaimTypes.NameIdentifier); }
        }
        public string UserName
        {
            get { return FindFirstValue<string>(ClaimsIdentity.DefaultNameClaimType); }
        }
        public string Email
        {
            get { return FindFirstValue<string>(ClaimTypes.Email); }
        }
        public string FirstName
        {
            get { return FindFirstValue<string>(ClaimTypes.GivenName); }
        }
        public string LastName
        {
            get { return FindFirstValue<string>(ClaimTypes.Surname); }
        }
        public string DisplayName
        {
            get
            {
                var name = string.Format("{0} {1}", this.FirstName, this.LastName).Trim();
                return name.Length > 0 ? name : this.UserName;
            }
        }
        public IEnumerable<int> Roles
        {
            get { return FindValues<int>(ClaimTypes.Role); }
        }
        private T FindFirstValue<T>(string type)
        {
            return Claims
                .Where(p => p.Type == type)
                .Select(p => (T)Convert.ChangeType(p.Value, typeof(T), CultureInfo.InvariantCulture))
                .FirstOrDefault();
        }
        private IEnumerable<T> FindValues<T>(string type)
        {
            return Claims
                .Where(p => p.Type == type)
                .Select(p => (T)Convert.ChangeType(p.Value, typeof(T), CultureInfo.InvariantCulture))
                .ToList();
        }
    }
