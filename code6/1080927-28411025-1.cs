    void Main()
    {
        var lst = new List<string>();
        lst.Add("test1");
        lst.Add("test2");
        lst.Add("test3");
        
        IQueryable<string> q = lst.AsQueryable();
        
        PrintQueryInfo(  q.Where(x=>x.Contains('1')));
        
    }
    
    public void PrintQueryInfo(IQueryable q){
        Console.WriteLine(q.Expression.ToString());
    }
