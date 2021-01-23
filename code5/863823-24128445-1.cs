    public bool GetIsMultiLine(WebSupergoo.ABCpdf9.Objects.Field field)
    {
        var flags = Atom.GetInt(Atom.GetItem(field.Atom, "Ff"));
        var isMultiLine = GetIsBitFlagSet(flags, 13);
        return isMultiLine;
    }
    public bool GetIsRequired(WebSupergoo.ABCpdf9.Objects.Field field)
    {
        var flags = Atom.GetInt(Atom.GetItem(field.Atom, "Ff"));
        var isRequired = GetIsBitFlagSet(flags, 2);
        return isRequired;
    }
    public bool GetIsReadOnly(WebSupergoo.ABCpdf9.Objects.Field field)
    {
        var flags = Atom.GetInt(Atom.GetItem(field.Atom, "Ff"));
        var isReadOnly = GetIsBitFlagSet(flags, 1);
        return isReadOnly;
    }
    private static bool GetIsBitFlagSet(int b, int pos)
    {
        return (b & (1 << (pos - 1))) != 0;
    }
