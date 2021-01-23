    static TheDB myDB;
    public HomeController()
    {
        if (myDB == null)
        {
            myDB = new TheDB();
        }
    }
