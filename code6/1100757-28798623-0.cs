    private MyEnum _myEnum;
    public MyEnum MyEnumProperty 
    {  
        get 
        { 
           return _myEnum; 
        }
        set 
        { 
           _myEnum = value;
           UpdateMyEditor(value);
        }
     }
