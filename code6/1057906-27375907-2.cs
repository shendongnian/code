    public void DoSomething()
    {
        using (var context = new CRMContext())
        {
             var targetDate = DateTime.Today.AddDays(60).Date;
             var policies = context.Policies.Where(p => p.new_RenewalDate == targetDate);
             foreach (var policy in policies)
             {
                 Console.WriteLine(policy.new_RenewalDate); // etc...
             }
        }
    }
