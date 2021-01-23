    public void Main(string[] args)
    {
        MyMethod(param2: value);
        MyMethod(param1: value);
        MyMethod(param3: value);
    }
    
    public void MyMethod(string param1=null, int? param2=null, Datetime? param3=null)
    {
         //do something
    }
