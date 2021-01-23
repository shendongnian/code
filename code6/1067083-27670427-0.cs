    public void setBirthdate(int year, int month, int day)
    {
        try
        {
            Birthdate = new DateTime(year, month, day);
        }
        catch (Exception ex)
        {
            Birthdate = DateTime.Now;
        }
    } 
