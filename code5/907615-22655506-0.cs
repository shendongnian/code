    protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(() => SomeMethod(accID: 1000)));
    
           // etc
    }
