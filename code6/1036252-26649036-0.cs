    /// <summary>
    ///  A description of the regular expression:
    ///  
    ///  ^\*.*"
    ///      Beginning of line or string
    ///      Literal *
    ///      Any character, any number of repetitions
    ///      "
    ///  [keyword]: A named capture group. [.*?]
    ///      Any character, any number of repetitions, as few as possible
    ///  "
    ///  
    ///
    /// </summary>
        public static Regex regex = new Regex(
              "^\\*.*\"(?<keyword>.*?)\"",
            RegexOptions.IgnoreCase
            | RegexOptions.Multiline
            );
    
        // Capture all Matches in the InputText
         MatchCollection ms = regex.Matches(InputText);
