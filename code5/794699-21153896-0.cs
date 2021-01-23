        //To get the result with leading zero's in excel this code is written.
            DataTable dtUpdated=new DataTable();
            //This gives similar schema to the new datatable
            dtUpdated = dtReports.Clone();
                foreach (DataRow row in dtReports.Rows)
                {
                    for (int i = 0; i < dtReports.Columns.Count; i++)
                    {
                        string oldVal = row[i].ToString();
                        string newVal = "&nbsp;"+oldVal;
                        row[i] = newVal;
                    }
                    dtUpdated.ImportRow(row); 
                }
