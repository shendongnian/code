    using (var session = new  Configuration().Configure().BuildSessionFactory().OpenSession())  
    {  
        table1 t1 = new table1();
        t1.table2s.Add(new table2());
        using (ITransaction transaction = session.BeginTransaction())  
        {  
            session.Save(t1);
            transaction.Commit();  
        }  
    }  
