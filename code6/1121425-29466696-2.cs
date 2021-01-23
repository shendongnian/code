    public bool Insert(string fname, string lname, out string message)
    {
        string message = string.Empty;
        try
        {
            peopleTableAdapters.PeopleTableAdapter peopleTA= new peopleTableAdapters.PeopleTableAdapter();
            peopleTA.insertQuery(fname, lname);
    
            // return true since no exception occurred
            message = "Success!";
            return True;
    
        }
        catch(Exception ex)
        {
            message = "Error! "+ ex.Message.ToString();
            return False;
        }
    }
