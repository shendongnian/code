    public interface IUserAddedInformation
    {
        Guid UserKey { get; set; }
        InformationType { get; set; }
    }
    public enum InformationType 
    {
        Address,
        CreditCard
    }
