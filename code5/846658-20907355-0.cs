    public interface IIdentifier
    {
        string Id { get; set; }
    }
    public static T GetCountry<T>(int portalID) where T : IIdentifier
    {
        T theCountry = (T)Activator.CreateInstance(typeof(T));
        theCountry.Id = "AR";
        if (portalID == 1) theCountry.Id = "ARG";
        return theCountry;
    }
