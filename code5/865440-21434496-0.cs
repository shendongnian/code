    //define somewhere in your class
    enum states { NOT_IN_QUOTES, IN_QUOTES }
    //inside a function
    states state = states.NOT_IN_QUOTES;
    string result = "";
    foreach(char c in str)
    {
        switch(state)
        {
             case states.NOT_IN_QUOTES:
                 if (c == '\"')
                 {
                     state = states.IN_QUOTES;
                 }
             break;
             case states.IN_QUOTES:
                 if (c == '\"')
                 {
                     state = states.NOT_IN_QUOTES;
                 }
                 else
                 {
                      result += c;
                 }
             break;
         }
    }
    return result;
        
