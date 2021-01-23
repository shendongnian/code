            DataSet ds = new DataSet("EmployeeList");
            //create table address
            DataTable address = new DataTable("Address");
            DataColumn column;
            //add column id
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName  = "ID";
            address.Columns.Add(column);
            //address.PrimaryKey = new DataColumn[1] { column };
            //add column City
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "City";
            address.Columns.Add(column);
            //add column State
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "State";
            address.Columns.Add(column);
            //add column Country
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Country";
            address.Columns.Add(column);
            ds.Tables.Add(address); //add table address to dataset
            //create table employee
            DataTable employee = new DataTable("Employee");
            //add column ID
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            employee.Columns.Add(column);
            employee.PrimaryKey = new DataColumn[1] { column };
            //add column Name
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            employee.Columns.Add(column);
            //add column Address
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Int32");
            //column.ColumnName = "Address";
            //employee.Columns.Add(column);
            ds.Tables.Add(employee); //add table employee to dataset
            //set foreign key constraint
            //ForeignKeyConstraint fk = new ForeignKeyConstraint("AddressFK", 
            //ds.Tables["Address"].Columns["ID"], ds.Tables["Employee"].Columns["Address"]);
            //fk.DeleteRule = Rule.None;
            //ds.Tables["Employee"].Constraints.Add(fk);
            //
            // fill data to data set
            //
            DataRow row;
            row = address.NewRow();
            row["ID"] = 1;
            row["City"] = "test";
            row["State"] = "test";
            row["Country"] = "test";
            address.Rows.Add(row);
            row = employee.NewRow();
            row["Name"] = "abc";
            row["ID"] = 1;
            //row["Address"] = 1;
            employee.Rows.Add(row);
            DataRelation relation = ds.Relations.Add("relation", ds.Tables["Employee"].Columns["ID"], ds.Tables["Address"].Columns["ID"]);
            relation.Nested = true;
            ds.WriteXml("test.txt"); //create xml from dataset
