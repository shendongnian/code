    /// <summary>
    ///  Regular expression built for C# on: Sun, Aug 25, 2013, 12:34:57 PM
    ///  Using Expresso Version: 3.0.4334, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  Match expression but don't capture it. [Including Millionaire Raffle\r\n]
    ///      Including Millionaire Raffle\r\n
    ///          Including
    ///          Space
    ///          Millionaire
    ///          Space
    ///          Raffle
    ///          Carriage return
    ///          New line
    ///  [LotteryNumber]: A named capture group. [.*]
    ///      Any character, any number of repetitions
    ///  Match expression but don't capture it. [\s.*\r\n]
    ///      \s.*\r\n
    ///          Whitespace
    ///          Any character, any number of repetitions
    ///          Carriage return
    ///          New line
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "(?:Including Millionaire Raffle\\r\\n)(?<LotteryNumber>.*)(?:\\s.*\\r\\n)",
        RegexOptions.CultureInvariant
        | RegexOptions.Compiled
        );
