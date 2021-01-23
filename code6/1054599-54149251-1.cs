    public void Main()
            {  //Take a copy of the Cloned Dataset
                DataTable dtRead = (Dts.Variables["TblClone"].Value as DataTable).Copy();
    
                //Lock the output object variable
                Dts.VariableDispenser.LockForWrite("User::ProcTbl");
    
                //Create a data table to place the results into which we can write to the output object once finished
                DataTable dtWrite = new DataTable();
    
                //Create elements to the Datatable programtically
                //dtWrite.Clear();
                
                dtWrite.Columns.Add("ID", typeof(Int64));
                dtWrite.Columns.Add("Nm");
    
                //Start reading input rows
                foreach (DataRow dr in dtRead.Rows)
                {
                    //If 1st col from Read object = ID var 
                    if (Int64.Parse(dr[9].ToString()) == 1) //P_Rnk = 1 
                    {
                        DataRow newDR = dtWrite.NewRow();
    
                            newDR[0] = Int64.Parse(dr[0].ToString());
                            newDR[1] = dr[4].ToString();
    
                        //Write the row
                        dtWrite.Rows.Add(newDR);
                    }
                }
    
                //Write the dataset back to the object variable
                Dts.Variables["User::ProcTbl"].Value = dtWrite;
                Dts.Variables.Unlock();
    
                Dts.TaskResult = (int)ScriptResults.Success;
            }
