    public bool Insert(string fname, string lname)
        {
            try
            {
                peopleTableAdapters.PeopleTableAdapter peopleTA= new peopleTableAdapters.PeopleTableAdapter();
                peopleTA.insertQuery(fname, lname);
                // return true since no exception occured
                return True;
    
            }
            catch(Exception ex)
            {
                return False;
            }
        }
