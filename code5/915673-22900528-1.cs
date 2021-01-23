    public string XCoor
    {
        get { return this.xCoor; }
        set { 
           if(value < 0) 
               throw new Exception("Negative values not allowed");
           xCoor = value; 
        }
    }
