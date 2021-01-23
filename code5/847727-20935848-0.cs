    Dataset ds = new Dataset("Dataset");
    
    //create table address
    DataTable address = new DataTable("Address");
    DataColumn column;
    
    //add column id
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.int");
    column.Name = "ID";
    address.Columns.Add(column);
    address.PrimaryKey = column;
    
    //add column City
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.Name = "City";
    address.Columns.Add(column);
    
    //add column State
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.Name = "State";
    address.Columns.Add(column);
    
    //add column Country
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.Name = "Country";
    address.Columns.Add(column);
    
    ds.Tables.Add(address); //add table address to dataset
    
    //create table employee
    DataTable employee = new DataTable("Employee");
    
    //add column Name
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.String");
    column.Name = "Name"
    employee.Columns.Add(column);
    
    //add column Address
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.int");
    column.Name = "Address";
    employee.Columns.Add(column);
    
    ds.Tables.Add(employee); //add table employee to dataset
    
    //set foreign key constraint
    ForeignKeyConstraint fk = new ForeignKeyConstraint("AddressFK", 
    ds.Tables["Address"].Columns["ID"], ds.Tables["Employee"].Columns["Address"]);
    
    fk.DeleteRule = Rule.None;
    ds.Tables["Employee"].Constraint.Add(fk);
    
    //
    // fill data to data set
    //
    
    ds.WriteXml("test.txt"); //create xml from dataset
