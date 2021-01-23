    DateTime startDate = new DateTime();
    DateTime endDate = new DateTime();
    public void Connect()
    {
        //Do something
        startDate = DateTime.Now;
    }
    public void Disconnect()
    { 
       //Do something
       endDate = DateTime.Now;
       Console.Writeline(endDate.Subtract(startDate).TotalMinutes.ToString(););
    }
