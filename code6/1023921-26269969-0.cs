    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenDialog.Reset();
        OpenDialog.InitialDirectory = Directory.GetCurrentDirectory();
        OpenDialog.RestoreDirectory = false;
        OpenDialog.Filter = "Resource files (*.resx)|*.resx";
        if (OpenDialog.ShowDialog() == DialogResult.OK)
        {
            StreamReader MyStream = new StreamReader(OpenDialog.FileName); 
            BBookGrid.DataSource = null;
            m_BBookTable.Clear();  //Clear the existing table
            ///BBookGrid.DataSource = m_BBookTable;  ///  this line should be
            // down after the catch i.e. after the data source is filled!!
            try
            {
                while (true)
                {
                    String MyLine = MyStream.ReadLine();
                    if (MyLine == null)
                    {
                        break;
                    }
                    else if (MyLine.Length != 0)
                    {
                        String[] fields = MyLine.Split(Separator.ToCharArray());
                        if (fields.GetLength(0) == NumColumns)
                        {
                            m_BBookTable.Rows.Add(m_BBookTable.NewRow());
                            m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][SourceCol]
                                       = fields[0].Trim();
                            m_BBookTable.Rows[m_BBookTable.Rows.Count - 1][TargetCol] 
                                      = fields[1].Trim(); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error" + ex.ToString());
                Application.Exit();
            }
            // now that is has data we set the data source!  
            BBookGrid.DataSource = m_BBookTable;
        }
    }
