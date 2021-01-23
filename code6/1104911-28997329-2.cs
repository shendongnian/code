    public interface IUserAddedInformation
    {
        Guid UserKey { get; set; }
        InformationType informationType { get; set; }
    }
    public enum InformationType 
    {
        Address,
        CreditCard
    }
