    ///<summary>  
    ///  First or last character in a word
    ///  [1]: A numbered capture group. [\S+]
    ///      Anything other than whitespace, one or more repetitions
    ///  \.\.
    ///      Literal .
    ///      Literal .
    ///  [2]: A numbered capture group. [\S+]
    ///      Anything other than whitespace, one or more repetitions
    ///  First or last character in a word
    ///  
    ///
    /// </summary>
    public Regex MyRegex = new Regex(
                "\\b(\\S+)\\.\\.(\\S+)\\b",
                RegexOptions.IgnoreCase
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
                );
    // This is the replacement string
    public string MyRegexReplace = "$2@$1_LNK";
    //// Replace the matched text in the InputText using the replacement pattern
    string result = MyRegex.Replace(InputText,MyRegexReplace);
