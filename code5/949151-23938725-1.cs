    public interface IFlag
    {
        bool Flag { get; }
    }
    namespace MyResponses.Interfaces.IInterface1
    {
        public partial class ExResponse : IFlag {}
    }
    namespace MyResponses.Interfaces.IInterface2
    {
        public partial class ExResponse : IFlag {}
    }
    // etc
