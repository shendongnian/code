    private static void Main(string[] args)
            {
    
                var fullName = ClaimsPrincipal.Current.GetFullName();
            }
    
            public static string GetFullName(this ClaimsPrincipal principal)
            {
    
                if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Surname) ||
                    !principal.HasClaim(claim => claim.Type == ClaimTypes.GivenName))
                {
                    var dcUsername = principal.Identity;
                    // get the value from dc.
                    var de = new DirectoryEntry("WinNT://" + dcUsername);
    
                    var claims = new List<Claim> {new Claim(ClaimTypes.GivenName, ""), new Claim(ClaimTypes.Surname, "")};
                    var id = principal.Identities.First();
                    id.AddClaims(claims);
                }
    
                var givenName = principal.FindFirst(ClaimTypes.GivenName).Value;
                var surname = principal.FindFirst(ClaimTypes.Surname).Value;
    
                return string.Format("{0} {1}", givenName, surname);
            }
