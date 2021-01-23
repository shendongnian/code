    public static List<Phone> GetPhones()
    {
        return GetListOfNonEmpties(context.Phones, p => p.Number);
    }
    public static List<Remote> GetRemotes()
    {
        return GetListOfNonEmpties(context.Remotes, r => r.OEM);
    }
