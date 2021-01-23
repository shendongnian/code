    Options: Case insensitive; Exact spacing; Dot matches line breaks; ^$ don't match at line breaks; Parentheses capture
    
    Match a single character that is a “whitespace character” (any Unicode separator, tab, line feed, carriage return, vertical tab, form feed, next line) «\s*»
       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    Match the character “$” literally «\$»
    Match a single character that is a “whitespace character” (any Unicode separator, tab, line feed, carriage return, vertical tab, form feed, next line) «\s*»
       Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    Match the regex below and capture its match into backreference number 1 «(.*)»
       Match any single character «.*»
          Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    
    \$1
    
    Insert the backslash character «\»
    Insert the text that was last matched by capturing group number 1 «$1»
