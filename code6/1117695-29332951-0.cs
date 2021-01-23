    // Summary:
    //     Gets the newline string defined for this environment.
    //
    // Returns:
    //     A string containing "\r\n" for non-Unix platforms, or a string containing
    //     "\n" for Unix platforms.
       public static string NewLine { get; }
    string[] words = str.Split(new[] { Environment.NewLine} , StringSplitOptions.None);
