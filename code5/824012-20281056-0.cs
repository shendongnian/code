    public LuaTable CreateTable()
    {
        return (LuaTable)lua.DoString("return {}")[0];
    }
    public LuaTable YourExportedFunction(string arg)
    {
        var table = CreateTable();
        table["A"] = arg;
        table["B"] = 123;
        return table;
    }
