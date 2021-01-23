    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    MyItem item = session.Get<MyItem>(44); //Item enthält ein Tag.
    
    item.Tags.Clear();
    
    tx.Commit(); 
                  
    session.Close();
