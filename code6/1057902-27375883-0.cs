    public class Class1 { 
    public List<Policy> DoSomething() { 
    using (var context = new CRMContext()) 
    {
      return context.Policies.Where(p => p.new_RenewalDate == DateTime.Today.AddDays(60).Date).ToList();
           
     }
     }
    }
    
    
    
    
    Class1 instance = new Class1();
    
    List<Policy> list = instance.DoSomething();
    
    foreach(Policy policy in list)
    {
    print what you want to print here :)
    }
