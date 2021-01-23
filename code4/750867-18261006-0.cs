    public string MiniButtonText
    {
       get
       {
           return GameInfo.IsMiniInserted == Visibility.Visible ? "Remove Mini" : "Insert Mini";
       }
    }  
