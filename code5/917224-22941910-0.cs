    public interface IPersistentEntity<out TIdent>
    {
        TIdent Id { get; }
        bool IsNew { get; }
    }
