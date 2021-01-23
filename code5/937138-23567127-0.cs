    protected string Active_Frozen(out string text, out string color)
    {
        connection();
        string query = "SELECT CustomerInfo FROM ActiveSubscription WHERE UserName=@UserName";
        SqlCommand cmd = new SqlCommand(query, conn);
        if(query=="true")
        {
           text = "Active";
           color = "Green";
        }
        else
        {
           text = "Frozen";
           color= "Red";
        }
    }
