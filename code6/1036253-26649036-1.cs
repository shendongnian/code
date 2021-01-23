        /// <summary>
        ///  A description of the regular expression:
        ///  
        ///  Beginning of line or string
        ///  [1]: A numbered capture group. [.*?\"(?<keyword>.*?)\"], one or more repetitions
        /// .*?\"(?<keyword>.*?)\"
        ///          Any character, any number of repetitions, as few as possible
        ///          Literal "
        ///          [keyword]: A named capture group. [.*?]
        ///              Any character, any number of repetitions, as few as possible
        ///          Literal "
        ///  
        ///
        /// </summary>
            public static Regex regex = new Regex(
                  "^(.*?\\\"(?<keyword>.*?)\\\")+",
                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                );
        
            // Capture all Matches in the InputText
             MatchCollection ms = regex.Matches(InputText);
