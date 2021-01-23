    public bool AddUser(string Name, int Contact, string Email, string Password, bool Admin, string ImageURL)
    {
        using (DataClassesDataContext dbcontext = new DataClassesDataContext())
        {
            try
            {
                var query = dbcontext.CreateUser(Name, Contact, Email, Password, Admin, ImageURL); 
                // If the execution got here then the insert succeeded
                // and you can return 'success' to caller
                return true;
            }
            catch(Exception ex)
            {
                // Log the exception
                // If the execution got here it means that the insert failed and 
                // an exception was thrown (in other words the execution didn't get to 
                // the <return true;> instruction.
                // In this case return 'fail' to caller.
                return false;
            }
            
        }
        return result;
    }
