    public void register_user(string First_Name,string Last_Name,string User_Name,string Password,string Date_Of_Birth,string Security_Question,string Security_Answer)
    { 
        DAL obj = null; // initialize to a value
        try
        {
            obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("UR", First_Name, Last_Name, User_Name, Password, Date_Of_Birth, Security_Question, Security_Answer);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            if (obj!=null)  // check for null in case the constructor did throw an exception
            {
              obj = new DAL();
              obj.CloseConnection();
            } 
            else
            {
                Debug.Assert(obj!=null, "DAL not intialized");
            }
        }   
       } 
