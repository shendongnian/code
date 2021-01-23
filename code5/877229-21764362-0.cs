     public class UsersSections
     {
        public int SectionId { get; set; }
        public int UserId { get; set; }
     }
     var userSectionsList = new List<UsersSections>
            {
                new UsersSections
                {
                    SectionId = 1000,
                    UserId = 200
                },
                new UsersSections
                {
                    SectionId = 2000,
                    UserId = 200
                }
            };
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,"I am a user with a userid of 200"));
            foreach (var usersSections in userSectionsList)
            {
                identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/section","1000"));
            }
            if (identity.HasClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/section", "1000"))
            {
               
            }
