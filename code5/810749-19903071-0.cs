    public interface IAutObj
    {
        string pw {get;set;}
    }
    namespace A
    {
        partial class AutObj : IAutObj {}
    }
    namespace B
    {
        partial class AutObj : IAutObj {}
    }
    namespace C
    {
        partial class AutObj : IAutObj {}
    }
