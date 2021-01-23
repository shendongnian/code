    private EntityRef<TextbausteinTyp> _textbausteinTyp;
    [Association(Storage = "_textbausteinTyp", ThisKey = "IdBausteintyp")]
    public TextbausteinTyp TextbausteinTyp
    {
        get { return _textbausteinTyp.Entity; }
        set { _textbausteinTyp.Entity = value; }
    }
