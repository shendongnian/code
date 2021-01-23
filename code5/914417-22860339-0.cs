    IEnumerable<TabTransaktion> mainQuery
        = TabTransaktions1.Union(TabTransaktions2)
                          .Where(trans => trans.TabVorgang != null);
    
    var queryOne  =  mainQuery.Where(p=>p.SalariedFlag ==1)
                           .OrderByDescending(tran => tran.BusinessEntityID );
    
    var queryTwo  =  mainQuery.Where(p=>p.SalariedFlag ==0)
                           .OrderBy(tran => tran.BusinessEntityID);
    
    var finalResult = queryOne.Union(queryTwo);
