    public AccessTokenResult CreateAccessToken(DotNetOpenAuth.OAuth2.Messages.IAccessTokenRequest accessTokenRequestMessage) {
            var accessToken = new AuthorizationServerAccessToken();
            accessToken.Lifetime = TimeSpan.FromDays(30);
            accessToken.ResourceServerEncryptionKey = ResourceServerEncryptionPublicKey();
            accessToken.AccessTokenSigningKey = AuthorizationServerSigningPrivateKey();
           
            var result = new AccessTokenResult(accessToken);
            return result;
        }
