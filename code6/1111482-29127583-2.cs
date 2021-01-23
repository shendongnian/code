    using System.Linq;
    public string removeChar(string LicID)
    {
        return (LicID ?? "").Split('.').First();
    }
