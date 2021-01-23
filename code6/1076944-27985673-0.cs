    string str = "test-test";
    bool allow = str.Any(c => Char.IsLetterOrDigit(c));  //true
    string str2 = "____!&&**^%$##@";      
    bool allow2 = str2.Any(c => Char.IsLetterOrDigit(c)); // false
    string str3 = "(999)-998-1111";
    bool allow3 = str3.Any(c => Char.IsLetterOrDigit(c)); // true  
