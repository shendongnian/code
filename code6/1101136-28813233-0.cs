    //Assuming example input "Stephen Smith-Jones" or "Stephen Smith Jones"
    //split on spaces and hyphens
    string[] names = FullName.Text.ToString().Split(new string[]{" ", "-"}, StringSplitOptions.RemoveEmptyEntries); //in case of extra spaces?
    //Stephen.Jones@domain.com
    var email = String.Format("{0}.{1}@domain.com", names[0], names[names.Length-1]);
    //  OR: Stephen.Smith@domain.com
    // var email = String.Format("{0}.{1}@domain.com", names[0], names[1]);
    
