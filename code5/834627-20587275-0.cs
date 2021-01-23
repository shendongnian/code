    //Location of CSV File
            string CSVDataBase = @"C:\CSVDatabase.csv";
    
            //Create Collection for DataGrid Source
            ICollection CreateDataSource()
            {
                //Create new DataTables and Rows
                DataTable dt = new DataTable();
                DataRow dr;
    
                //Create Column Headers
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Age", typeof(string)));
                dt.Columns.Add(new DataColumn("Gender", typeof(string)));
    
                //For each line in the File
                foreach (string Line in File.ReadLines(CSVDataBase))
                {
                    //Split lines at delimiter ';''
                    //Create new Row
                    dr = dt.NewRow();
    
                    //ID=
                    dr[0] = Line.Split(';').ElementAt(0);
    
                    //Name =
                    dr[1] = Line.Split(';').ElementAt(1);
    
                    //Age=
                    dr[2] = Line.Split(';').ElementAt(2);
    
                    //Gender= 
                    dr[3] = Line.Split(';').ElementAt(3);
    
                    //Add the row we created
                    dt.Rows.Add(dr);
                }
    
                //Return Dataview 
                DataView dv = new DataView(dt);
                return dv;
            }
