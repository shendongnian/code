    protected Container Active_Frozen(string text, string color)
         {
    
        connection();
    
        string query = "SELECT CustomerInfo FROM ActiveSubscription WHERE UserName=@UserName";
    
        SqlCommand cmd = new SqlCommand(query, conn);
    
    
        if(query=="true")
        {
           Container c = new Container{text = "Frozen",color= "Red"};
        }
    
        else
        {
           Container c = new Container{text = "Frozen",color= "Red"};
        }
    
        return c;
    }
