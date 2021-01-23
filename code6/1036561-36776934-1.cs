        [Authorize]
        public async Task<int> Test()
		{
            var claims = (Context.User.Identity as System.Security.Claims.ClaimsIdentity).Claims.FirstOrDefault();
            if (claims != null)
            {
                var userId = claims.Value;
                
                //security party!
                return 1;
            }
            
            return 0;
		}
