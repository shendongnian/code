    var todaysdate = DateTime.Today;
    DateTime dt;
    if (DateTime.TryParse(acct.maturityDate, out dt) 
    {
        if (dt <= todaysdate)
        {
           maturityText.Visible = true;  
        }
    }
   
