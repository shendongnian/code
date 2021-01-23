    public interface IUser
    {
        int AthleteId { get; set; }
        string GivenName { get; set; }
        string FamilyName { get; set; }         
        bool IsActive { get; set; }
    }
    public  class DjsNameAutoSearch<Result, User> : where User : class, IUser, new()
