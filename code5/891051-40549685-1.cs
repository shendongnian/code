    // using Z.EntityFramework.Plus; // Don't forget to include this.
    
    // DELETE directly in SQL (without loading entities)
    db.Tables.Where(_ => _.Column == 'SomeRandomValue'
                         && _.Column2 == 'AnotherRandomValue')
    		 .Delete();
    
    // DELETE using a BatchSize		 
    db.Tables.Where(_ => _.Column == 'SomeRandomValue'
                         && _.Column2 == 'AnotherRandomValue')
    		 .Delete(x => x.BatchSize = 1000);
    
