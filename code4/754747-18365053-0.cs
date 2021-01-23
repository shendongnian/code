    private bool IsVar1Blank(string var1)
    {
        return string.IsNullOrWhiteSpace(var1);
    }
    private bool IsVar2SetToYes(string var2)
    {
        return var2 == "YES";
    }
    private bool IsAnOtherVariableNotSetToNo(string var3, string var4, string var5)
    {
        return var3 != ("NO") || var4 != ("NO") || var5 != ("NO");
    }
