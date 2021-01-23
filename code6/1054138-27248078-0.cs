    public void updateDB(object whatever)
    {
        foreach(var prop in whatever.GetType().GetProperties())
        {
           ... //do stuff
        }
    } 
