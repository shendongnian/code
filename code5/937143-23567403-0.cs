    protected list<string> Active_Frozen(string text, string color)
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
        list<string> liststring = new list<string> { text, color};
        return liststring;
