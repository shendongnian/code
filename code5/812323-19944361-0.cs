    [ServiceContract]
    [ServiceKnownType(typeof(UserData))]
    public interface IUserData
    {
      ExchangeVersion ExchangeVersion { get; }
      string UserName { get; set; }
      string EmailAddress { get; set; }
      string Domain { get; set; }
      string Password { get; set; }
      Uri AutodiscoverUrl { get; set; }
      Uri ExchangeUrl { get; set; }
    }
