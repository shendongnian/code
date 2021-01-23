    protected void getEventDetails()
    {
         lblDate.Text = getDate(ds.Tables[0].Rows[0]["EventDate"].ToString());
    }
    
    
    protected string getDate(object dt)
    {
       return DateTime.Parse(dt.ToString()).ToString("MMMM dd, yyyy");
    }
