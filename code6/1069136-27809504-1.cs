    public class TestRefreshTokenHandler : IRefreshTokenHandler
    {
        public Task SaveRefreshTokenAsync(RefreshTokenInfo tokenInfo)
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("\r\nUserID = " + tokenInfo.UserId);
                Console.WriteLine("\r\nRefresh Token = " + tokenInfo.RefreshToken);
                Console.WriteLine("\r\n------------------------");
            });
        }
        public Task<RefreshTokenInfo> RetrieveRefreshTokenAsync()
        {
            Console.WriteLine("RetrieveRefreshTokenAsync()");
            return Task.FromResult(new RefreshTokenInfo(OneNoteTestConfig.OneNoteRefreshToken));
        }
    }
