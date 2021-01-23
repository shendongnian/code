    // I first tried: \{\s*((public\s*\w*\s*)\w*(\s*?{\s*?get;\s*?})\s*?=\s*?\w*;\s*)*\}
    // Which means: 
    \{       // starting with {
    \s*      // <whitespace (any amount, including linebreaks)>
    (        // capture1; followed by a sequence of possibly repeating... 
      (      // capture2: public <whitespace> <word> <whitespace>
      public\s* // 'public' <whitespace> 
      \w*\s*    // <a word (any amount of letters)> <whitespace> // type
      )     // end of caputure2
      \w*\s*?   // <word> <possible-whitespace>         // variable name
      (    // capture2: { get }
      \{\s*?get;\s*?\}  // '{ <possible-whitespace> get; <possible-whitespace> }'
      )
      \s*?=     // <possible-whitespace> '='
      \s*?\w*   // <possible-whitespace> '<word> ;'
