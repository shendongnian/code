    // This is your credentials type
    class Credentials : ICredentials
    {
        static ICredentials Load();
        static void Save(ICredentials credentials, IPin pin);
        static void Delete(ICredentials credentials);
        bool Validate();
        bool CheckPin(IPin pin);
    }
    class Pin : IPin
    {
        static IPin Validate(string pin);
    }
    static class Internet
    {
        static bool Available { get; }
    }
