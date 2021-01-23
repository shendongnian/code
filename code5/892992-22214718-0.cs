    public class LoginService : ILoginService 
    {    
        public async Task<bool> LoginAsync (string username, string password, CancellationToken cancellationToken = default(CancellationToken)) 
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1000), cancellationToken);
            return true;
        }
    }
