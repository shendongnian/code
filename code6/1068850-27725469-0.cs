    public Boolean Delete(Int32 HolidayNo)
    {
        try
        {
            clsDataConnection MyDatabase = new clsDataConnection();
            MyDatabase.AddParameter("@HolidayNo", HolidayNo);
            MyDatabase.Execute("sproc_tblHolidays_Delete");
            return true;
        }    
        catch
        {
            return false;
        }
    }
