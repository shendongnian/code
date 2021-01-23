            var dataProtectorProvider = AuthConfig.DataProtectionProvider;
            var dataProtector = dataProtectorProvider.Create("My Asp.Net Identity");
            this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, Guid>(dataProtector)
            {
                TokenLifespan = TimeSpan.FromHours(24),
            };
