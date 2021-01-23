    private EntitySet<Textbaustein> _textbausteins;
    [Association(Storage = "_textbausteins", OtherKey = "IdBausteintyp")]
    public EntitySet<Textbaustein> Textbausteins
    {
        get { return _textbausteins; }
        set { _textbausteins.Assign(value); }
    }
