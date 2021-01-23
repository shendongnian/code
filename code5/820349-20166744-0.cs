     Cursor = Cursors.WaitCursor;
                frmSalesinvoice frm = new frmSalesinvoice();
                invoice rpt = new invoice();
                //The report you created.
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DS_Invoice_all myDS = new DS_Invoice_all();
                myConnection = new SqlConnection(cs);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "select * from Invoice_Info INNER JOIN Items_Soled ON
     Items_Soled.Invoice_No=Invoice_Info.Invoice_No WHERE [TableName].Invoice_No = '" + textBoxInvoiceNo.Text + "'";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "Invoice_Info");
                myDA.Fill(myDS, "Items_Soled");
                rpt.SetDataSource(myDS);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
