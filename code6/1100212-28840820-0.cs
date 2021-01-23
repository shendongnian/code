    var data = @"
    pulin Tester  { class Main { } class Omega{} }
    pulin Tester2 { }
    ";
    
    var pattern = @"
    pulin\s*                   # Look for our anchor which identifies the current namespace,
                               # it will designate each namespace block
    (?<Namespace>[^\s{]+)      # Put the namespace name into the named match capture `Namespace`.
        (                      # Now look multiple possible classes
          .+?                  # Ignore all characters until we find `class` text
          (class\s             # Found a class, let us consume it until we find the textual name.
             (?<Class>[^\{]+)  # Insert the class name into the named match capture `Class`.
          )
        )*                     # * means 0-N classes can be found.
                        ";
    
    // We use ignore pattern whitespace to comment the pattern.
    // It does not affect the regex parsing of the data.
    Regex.Matches(data, pattern, RegexOptions.IgnorePatternWhitespace)
         .OfType<Match>()
         .Select (mt => new
         {
         	Namespace = mt.Groups["Namespace"].Value,
            Classes   = mt.Groups["Class"].Captures
                                          .OfType<Capture>()
                                          .Select (cp => cp.Value)
         })
         .Dump();
