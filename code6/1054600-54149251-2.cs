    public void Main()
        {   
            //Clone the copied table
            DataTable dtRead = (Dts.Variables["TblClone"].Value as DataTable).Copy();
    
            //Read the var to filter the records by
            var ID = Int64.Parse(Dts.Variables["User::ProcID"].Value.ToString());
    
            //Lock the output object variable
            Dts.VariableDispenser.LockForWrite("User::SubTbl");
    
            //Debug Test the ProcID being passed
            //MessageBox.Show(@"Start ProcID =  " + ID.ToString());
            //MessageBox.Show(@"TblCols =  " + dtRead.Columns.Count);
    
            //Create a data table to place the results into which we can write to the output object once finished
            DataTable dtWrite   = new DataTable();
    
            //Create elements to the Datatable programtically
            //dtWrite.Clear();
            foreach (DataColumn dc in dtRead.Columns)
            {
                dtWrite.Columns.Add(dc.ColumnName, dc.DataType);
            }
    
            MessageBox.Show(@"TblRows =  " + dtRead.Rows.Count); 
            //Start reading input rows
            foreach (DataRow dr in dtRead.Rows)
            {
                //If 1st col from Read object = ID var 
                if (ID == Int64.Parse(dr[0].ToString()))
                {
                    DataRow newDR = dtWrite.NewRow();
    
                    //Dynamically create data for each column
                    foreach (DataColumn dc in dtRead.Columns)
                    {
                        newDR[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    //Write the row
                    dtWrite.Rows.Add(newDR);
    
                    //Debug
                    //MessageBox.Show(@"ProcID =  " + newDR[0].ToString() + @"TaskID =  " + newDR[1].ToString() + @"Name = " + newDR[4].ToString());
                }
    
            }
            //Write the dataset back to the object variable
            Dts.Variables["User::SubTbl"].Value = dtWrite;
            Dts.Variables.Unlock();
    
            Dts.TaskResult = (int)ScriptResults.Success;
        }
