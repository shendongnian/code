    public interface IDBSAve {} //generic interface 
    
    public class Table1Saver : IDBSave {} //class that saves ONLY in Table1 
    public class Table2Saver : IDBSave {} //class that saves ONLY in Table2
    
    //business process that requires save in these 2 tables
    var twoTablesBusinessProcess = new List<IDBSave> {new Table1Saver(), new Table2saver()}; 
    //execute save in all calling chanin of this business process and if ALL 
    //succeed, confirm commit.
    if(twoTablesBusinessProcess.All(save=>save.SaveTable())) 
        context.SaveChanges(); 
     
