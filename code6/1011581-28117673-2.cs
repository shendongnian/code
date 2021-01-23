    private void btnimportexcel_Click(object sender, EventArgs e)
        {
            string source = string.Empty;
            source = cmbImportsource.Text;
            if (!string.IsNullOrEmpty(source ))
            {
                string smsfilename=string .Empty ;
                OpenFileDialog of = new OpenFileDialog();
                DialogResult dlresult;
                
                of.InitialDirectory = Environment.SpecialFolder.Desktop.ToString ();
                switch (source)
                {
                    case "EXCEL":
                         of.Filter = "Excel File(*.xlsx,*.xls)|*.xlsx;*.xls|All Files(*.*)|*.*";
                         of.Title = "Select Excel File...";
                          dlresult = of.ShowDialog();
                           if (dlresult == DialogResult.OK )
                            {
                                 smsfilename = of.FileName;
                               if (System.IO.File.Exists(smsfilename))
                               {
                                   getRecordFromXcel(smsfilename);
                               }
                            }
               
                        break;
                    case "CSV":
                        //"Text and CSV Files(*.txt, *.csv)|*.txt;*.csv|Text Files(*.txt)|*.txt|CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
                        of.Filter = "CSV Files(*.csv)|*.csv|All Files(*.*)|*.*";
                        of.Title = "Select Excel File...";
                          dlresult = of.ShowDialog();
                           if (dlresult == DialogResult.OK )
                            {
                                 smsfilename = of.FileName;
                               if (System.IO.File.Exists(smsfilename))
                               {
                                   getRecordFromCSV(smsfilename);
                               }
                            }
                        break;
                    case "TEXT FILE":
                        break;
                }
            }
