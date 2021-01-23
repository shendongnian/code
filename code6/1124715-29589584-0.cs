    void InsertPing(Ping p)
    {
          db.Insert(p);
    }
   
    void InsertGroupOfPings(IEnumerable<Ping> pings)
    {
       db.InsertAll(pings);
    }
