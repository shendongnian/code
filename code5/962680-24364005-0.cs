    public class CompanyVM
    {
    
    public int Company {get;set;}
    public int Count {get;set;}
    public int Amount {get;set;}
    }
    var balance = bal.GroupBy(d => d.Compnay).Select(
                                                cl => new CompanyVM
                        {
                            Company = cl.Key,
                            Count = cl.Count(),
                            Amount = cl.Sum(c => c.Amount)
                        }).ToList();
