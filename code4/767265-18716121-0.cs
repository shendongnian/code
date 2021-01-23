    // This is your credentials type
    class Credentials : ICredentials
    {
        static ICredentials Load();
        static void Save(ICredentials credentials, string pin);
        static void Delete(ICredentials credentials);
        bool Validate();
        bool CheckPin(string pin);
    }
    static class Internet
    {
        static bool Available { get; }
    }
