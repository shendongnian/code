        @using System.Security.Claims
        @using Microsoft.AspNet.Identity
        @{      
           var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
           var customUserClaim = claimsIdentity != null ? claimsIdentity.Claims.FirstOrDefault(x => x.Type == "cutomType") : null;
           var customTypeValue= customUserClaim != null ? customUserClaim .Value : User.Identity.GetUserName();
           var roleOfUser = claimsIdentity != null ? claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value :"User";
           
    }
