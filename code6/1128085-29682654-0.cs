    public IQueryable<Phone> GetPhones(){
        return context.Phones
                      .Where(p=> !String.IsNullOrWhiteSpace(p.Number));
    }
    
    public IQueryable<Remote> GetRemotes(){
        return context.Remotes
                      .Where(r => !String.IsNullorWhiteSpace(r.OEM));
    }
