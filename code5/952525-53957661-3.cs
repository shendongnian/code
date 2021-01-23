    /// <summary>
        /// Get OAuth token
        /// </summary>
        /// <returns></returns>
        public string GetOAuthToken()
        {
            return googleCredential.UnderlyingCredential.GetAccessTokenForRequestAsync("https://accounts.google.com/o/oauth2/v2/auth", CancellationToken.None).Result;
        }
