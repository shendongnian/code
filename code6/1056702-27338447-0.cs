    public List<Account> DoesNotReturnAnyData() {
    
        //Obviously I would use a parameter, but even this test fails
        string searchText = "Test";  
    
        using (var db = new MyEntities()){
    
                return (from a in db.Accounts
                        where a.accountname.Contains(searchText )
                        select a).ToList();
        }
    }
