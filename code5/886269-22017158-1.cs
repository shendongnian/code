    var grouped = fd.GroupBy((a => new { a.itemid,a.name }) into grp 
                  select new MyClass
                  {
                      MyProperty1=grp.key.itemid,
                      MyProperty2 =grp.Sum(x=>x.whatever)
                  }
    Public MyClass
    {
       public string MyProperty1 {get;set;}
       public int MyProperty2 {get;set;}
    }
    
