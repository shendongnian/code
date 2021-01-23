    private bool a;
    
    public bool A
    {
        get { return a; }
        set 
        { 
            if (value == B)
            {
                throw new Exception("A and B have the same boolean value!");
            }
            else
                a = value;
        }
    }
