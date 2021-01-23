    /// <summary>
    ///  Regular expression built for C# on: Sun, Aug 25, 2013, 12:55:52 PM
    ///  Using Expresso Version: 3.0.4334, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  Match expression but don't capture it. [Lucky Stars\r\n]
    ///      Lucky Stars\r\n
    ///          Lucky
    ///          Space
    ///          Stars
    ///          Carriage return
    ///          New line
    ///  [Numbers]: A named capture group. [.*\r\n], exactly 5 repetitions
    ///      .*\r\n
    ///          Any character, any number of repetitions
    ///          Carriage return
    ///          New line
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "(?:Lucky Stars\\r\\n)(?<Numbers>.*\\r\\n){5}",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
    
	
    public static Regex replaceRegex = new Regex(
          "(\\s-.*\r\n)",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
	
