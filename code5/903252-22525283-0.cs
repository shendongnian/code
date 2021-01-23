    public List<accType> Get(int id)
    {
      var accounts = (from c in db.account_type
                            where c.p_id == id
                            select new accType
                            {
                                id = c.id,
                                name = c.desc,
                                account = new List<account>
                                {
                                   name=c.desc
                                }
                            });
       return accounts.ToList()
    }
