    public interface IFlag
    {
        bool Flag { get; }
    }
    // This may not be exactly right - it's hard to tell your situation from the question
    namespace MyResponses.Interfaces
    {
        public partial class IInterface1
        {
            public partial class ExResponse : IFlag {}
        }
    }
    // etc
