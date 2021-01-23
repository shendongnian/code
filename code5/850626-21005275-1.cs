    public void MyMethod()
    {
       int x = 0; //method-scoped variable.
    
        for (int x = 0; x < 9; x++)  //for-scoped variable, with the same name, invalid.
        {
            //here you have 2 "x", which one to use? invalid.
        }
    
       //the first x is available here
    }
