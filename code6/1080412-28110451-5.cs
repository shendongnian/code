    public interface IUserService
    {
      bool IsAuthorized(string userName);
      string[] GetFavorites(string userName);
    }
