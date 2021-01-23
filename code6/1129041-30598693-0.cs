    var keybytes = Convert.FromBase64String(YOUR_CLIENT_SECRET);
            var signingCredentials = new SigningCredentials(
                        new InMemorySymmetricSecurityKey(keybytes),
                        SecurityAlgorithms.HmacSha256Signature,
                        SecurityAlgorithms.Sha256Digest);
            var nbf = DateTime.UtcNow.AddSeconds(-1);
            var exp = DateTime.UtcNow.AddSeconds(120);
            var payload = new JwtPayload(null, "", new List<Claim>(), nbf, exp);
            var users = new Dictionary<string, object>();
            users.Add("actions", new List<string>() { "read", "create" });
            var scopes = new Dictionary<string, object>();
            scopes.Add("users", users);
            payload.Add("scopes", scopes);
            var jwtToken = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(jwtToken);
