    Interface IShow
    {
 	  protected void ShowData();
    }
    Class A:IShow
    {
	  protected void ShowData()
	  {
		Console.writeline("This is Class A");
	  }
    }
    Class B: A
    {
	  protected new void ShowData()
	  {
		 Console.writeline("This is Class B");
	  }
     }
