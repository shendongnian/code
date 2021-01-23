            try
            {            
                //string FileName = @"\\tiwnas1\eng\legacy\XView_Results\Book1-xview-test.xlsx";
                //string theFile = GetPath(@"\\tiwnas1\eng\legacy\Book1-xview-test_v8.xls");
                //string FileName = @"\\tiwnas1\eng\legacy\Book1-xview-test_v8.xls";
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                string sql = null;
                string sql2 = null;
                string sql3 = null;
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\csharp.net-informations.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='\\\\tiwnas1\\eng\\legacy\\XView_Results\\Book1-xview-test.xlsx';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\Book1-xview-test.xlsx';Extended Properties='Excel 8.0;HDR=YES;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='\\tiwnas1\eng\legacy\XView_Results\Book1-xview-test.xlsx';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='H:\\Book1-xview-test_v8.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='h:\\Book1-xview-test_v8.xls';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='h:\\Book1-xview-test_v8.xls';Extended Properties='Excel 8.0;HDR=YES;';");
                //MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + FileName + "';Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
                MyConnection.Open();
                myCommand.Connection = MyConnection;
                //sql = "Update [Sheet1$] set result=5.625 where id=1";
                sql = "Update [Sheet1$] set result=" + od + " where id=1";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                //sql2 = "Update [Sheet1$] set result=5.375 where id=2";
                sql2 = "Update [Sheet1$] set result=" + id + " where id=2";
                myCommand.CommandText = sql2;
                myCommand.ExecuteNonQuery();
                //sql3 = "Update [Sheet1$] set result=110000 where id=3";
                sql3 = "Update [Sheet1$] set result=" + yield + " where id=3";
                myCommand.CommandText = sql3;
                myCommand.ExecuteNonQuery();
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
