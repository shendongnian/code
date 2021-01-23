                ds = new DataSet();
                string myConnStr = "";
                if (txtdestination.Contains(".xlsx"))
                {
                    myConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtdestination.ToString() + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                }
                else
                {
                    myConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtdestination.ToString() + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                }
                OleDbConnection myConn = new OleDbConnection(myConnStr);
                OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", myConn);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                myConn.Open();
                adapter.Fill(ds);
                myConn.Close();
