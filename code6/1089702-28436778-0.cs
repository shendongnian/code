    public interface IPrincipal 
    {
        IIdentity Identity { get; }
        bool IsInRole( string role );
    }
