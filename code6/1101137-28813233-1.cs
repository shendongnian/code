    //Assuming example input "Stephen Smith-Jones" or "Stephen Smith Jones"
    //split on spaces and hyphens
    string[] names = FullName.Text.ToString()
                         .Split(new string[]{" ", "-"},
                                StringSplitOptions.RemoveEmptyEntries); //in case of extra spaces?
    //Stephen.SmithJones@domain.com
    var email = String.Format("{0}.{1}{2}@domain.com",
                              names[0],
                              names[1],
                              (names.Length > 2) ? names[2] : "");
    
