    public void DoSomething()
    {
        using (var context = new CRMContext())
        {
             var policies = context.Policies.Where(p => p.new_RenewalDate == 
                             DateTime.Today.AddDays(60).Date).ToList();
             foreach (var policy in policies)
             {
                 Console.WriteLine(policy.new_RenewalDate); // etc...
             }
        }
    }
