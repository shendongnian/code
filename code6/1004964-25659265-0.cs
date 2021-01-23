    void Main()
    {
    	var list=new List<test>
    	{
    	  new test{ Debit=125, Credit=0},
    	  new test{ Debit=236,Credit=0},
    	  new test{ Debit=0, Credit=100},
    	};
    	if(list.Any())
    	{
    	   var first = list.First();
    	   first.Balance = first.Debit - first.Credit;
    	   list.Aggregate((x,y)=>{ y.Balance = x.Balance + y.Debit - y.Credit; return y;});
    	}
    
    	list.Dump();
    }
    class test
    {
       public int Debit {get;set;}
       public int Credit {get;set;}
       public int Balance {get;set;}
    }
