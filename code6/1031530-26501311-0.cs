    public class UserAccount
    {
       public int AccountId {  get; set;}
    
       public UserAccountState AccountState { get; set; }
    
       public Guid ActivationCode { get; set; }
    
       public string Password { get; set; }
    }
