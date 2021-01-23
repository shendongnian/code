    public void LoadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDLG = new OpenFileDialog();
            fileDLG.Title = "Open Excel File";
            fileDLG.Filter = "Excel Files|*.xls;*.xlsx";
            fileDLG.InitialDirectory = @"C:\Users\...\Desktop\";
    
            if (fileDLG.ShowDialog() == DialogResult.OK)
            {
                string filename = System.IO.Path.GetFileName(fileDLG.FileName);
                string path = System.IO.Path.GetDirectoryName(fileDLG.FileName);
                excelLocationTB.Text = @path + "\\" + filename;
                string ExcelFile = @excelLocationTB.Text;
                if (!File.Exists(ExcelFile))
                    MessageBox.Show(String.Format("File {0} does not Exist", ExcelFile));
    
                OleDbConnection theConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ExcelFile+";Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1;'");
                theConnection.Open();
                OleDbCommand theCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", theConnection);
                OleDbDataAdapter theDataAdapter = new OleDbDataAdapter(theCmd);
                DataSet DS = new DataSet();
                theDataAdapter.Fill(DS);
                theConnection.Close();
                dataGridView1.DataSource = DS.Tables[0];
                formatDataGrid();
                MessageBox.Show("Excel File Loaded");
                toolStripProgressBar1.Value += 0;
            }
        }
