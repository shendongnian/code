    class AccessTokenManager
    {
        private readonly SemaphoreSlim Mutex = new SemaphoreSlim(1, 1);
        private AccessToken LastSeenToken;
        public async Task<AccessToken> ResolveToken(CancellationToken ct)
        {
            await this.Mutex.WaitAsync(ct);
            try
            {
                if (this.LastSeenToken == null || !this.LastSeenToken.IsValid)
                {
                    this.LastSeenToken = await this.GetNewAuthTokenAsync(ct);
                }
                return this.LastSeenToken;
            }
            finally
            {
                this.Mutex.Release();
            }
        }
        private async Task<AccessToken> GetNewAuthTokenAsync(CancellationToken ct)
        {
            // Pure retrieve new token implementation.
        }
    }
