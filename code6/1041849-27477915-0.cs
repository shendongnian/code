    public static readonly string BLOCK_COMMENTS = @"/\*(.*?)\*/";
    public static readonly string LINE_COMMENTS  = @"--[^@](.*?)\r?\n";
    public static readonly string STRINGS        = @"""((\\[^\n]|[^""\n])*)""";
    string sWithoutComments = Regex.Replace(textWithComments.Replace("'", "\""), ServerConstant.BLOCK_COMMENTS + "|" + ServerConstant.LINE_COMMENTS + "|" + ServerConstant.STRINGS,
                    me =>
                    {
                        if (me.Value.StartsWith("/*") || me.Value.StartsWith("--"))
                            return me.Value.StartsWith("--") ? Environment.NewLine : "";
                        return me.Value;
                    },
                    RegexOptions.Singleline);
