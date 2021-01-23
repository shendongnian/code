    private IEnumerable<SomeClass> Filter(IEnumerable<SomeClass> aaa, string name, string company, string address,int? age)       
    {
        IEnumerable<SomeClass> ans = new SomeClass[0];
        if (!String.IsNullOrEmpty(name))
            ans = aaa.Where(x => x.name.Equals(name));
    
        if (!String.IsNullOrEmpty(company))
            ans = ans.Where(x => x.company.Equals(company));
    
        if (!String.IsNullOrEmpty(address))
            ans = ans.Where(x => x.address.Equals(address));
    
        if (age.HasValue)
            ans = ans.Where(x => x.age == age.Value);
    
        return ans.ToArray();
    }
