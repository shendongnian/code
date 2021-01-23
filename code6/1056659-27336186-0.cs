    private ChildObject child;
    public ChildObject Child
    {
        get {
           //if the chld hasnt been set already
            if (child == null)
            {
                //if the value of the integer has been set
                if(some_val != null)
                {
                    SomeMethod();
                }
            }
            return child;
        }
        set { child = value;}
    }
