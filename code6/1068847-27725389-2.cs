    public Boolean Delete(Int32 HolidayNo)
    {
        try
        {
            //provides the functionality for the delete class
        
            //create an instance of the data connection class called MyDatabase
            clsDataConnection MyDatabase = new clsDataConnection();
            //add the HolidayNo parameter passed to this function to the list of parameters to use in the database
            MyDatabase.AddParameter("@HolidayNo", HolidayNo);
            //execute the stored procedure in the database
            MyDatabase.Execute("sproc_tblHolidays_Delete");
            //return value for function
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
