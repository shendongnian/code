     class D : C
     {
	  public D()
	  {
     int valueAdd=((A)this).add(10,11);
	 int valueMul=((B)this).mul(20,11);	
     Console.WriteLine("Addition Value  of A= " +valueAdd+" multiplication value= "+valueMul);
	  }
	
	public D(int x,int y):this()
	{
     int valueAdd=((A)this).add(x,y);
	 int valueMul=((B)this).mul(x,y);	
     Console.WriteLine("Paremeterized Value  of A= " +valueAdd+" multiplication value= "+valueMul);
	}
    }
