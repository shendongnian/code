    foreach(var ch in string) {
       if(char.IsWhiteSpace(ch)) {
          ...
       }
       else {
          if(char.IsLetterOrDigit(ch)) {
             letterOrDigit++;
             if(char.IsDigit(ch)) digit++;
             if(char.IsLetter(ch)) letter++;
          }  
       }
    }
