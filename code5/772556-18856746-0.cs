    string SessionVariable
    {
       get{
          return Session("SessionVariable") ?? String.Empty;
       }
       set{
          Session("SessionVariable") = value;
       }
    }
