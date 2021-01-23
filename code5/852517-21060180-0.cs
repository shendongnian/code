    public interface IAccountRepository
    {
        Task AuthenticateAsync(string username, string password);
        Task RegisterAsync(string username, string password,AccountType accountType);
    }
