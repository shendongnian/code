            if (!_context.Users.Any(_ => _.Id.Equals(Users.AdministratorId)))
            {
                var user = new ApplicationUser
                {
                    Id = Users.AdministratorId,
                    UserName = Users.AdministratorEmail,
                    Email = Users.AdministratorEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = Users.AdministratorEmail.ToUpper(),
                    NormalizedUserName = Users.AdministratorEmail.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var hasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = hasher.HashPassword(user, "our_password");
                _context.Users.Add(user);
            }
