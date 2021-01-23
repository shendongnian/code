    Regex rgx = new Regex(pattern);
    string input = "This is   text with   far  too   much   " + 
                     "whitespace.";
    string pattern = "\\s*!\\s*";
    string replacement = "!";
    Regex rgx = new Regex(pattern);
    string result = rgx.Replace(input, replacement);
