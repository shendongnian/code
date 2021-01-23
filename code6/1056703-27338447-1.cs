    public List<Account> DoesNotReturnAnyData() {
    
        string searchText = "Test";  
    
        using (var db = new MyEntities()){
    
                return (from a in db.Accounts
                        where a.accountname.Contains(searchText )
                        select a).ToList();
        }
    }
