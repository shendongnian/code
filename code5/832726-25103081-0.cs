    private string Comments(EdmMember member)
    {
        string comments = member.Documentation != null
            ? (string.IsNullOrEmpty(member.Documentation.Summary)
                ? ""
                : @"
    /// <summary>
    /// " + member.Documentation.Summary.Replace("\n", Environment.NewLine + "    /// ") + @" 
    /// </summary>
    ")
                +
                (string.IsNullOrEmpty(member.Documentation.LongDescription)
                ? ""
                : @"/// <remarks>
    /// " + member.Documentation.LongDescription.Replace("\n", Environment.NewLine + "    /// ") + @"
    /// </remarks>
    ")
            : "";
        return comments;
    }
