      try
            {
                if (dgvData.Rows.Count > 0)
                {
                    xCellApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvData.Columns.Count + 1; i++)
                    {
                        xCellApp.Cells[1, i] = dgvData.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvData.Columns.Count; j++)
                        {
                            if (dgvData.Columns[j].HeaderText == "dates")
                            {
                                
                                DateTime dt = Convert.ToDateTime(dgvData.Rows[i].Cells[j].Value.ToString());
                                xCellApp.Cells[i + 2, j + 1] = dt.ToString("MM/dd/yyyy");
                              
                            }
                            else
                            {
                                xCellApp.Cells[i + 2, j + 1] = dgvData.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    xCellApp.Columns.AutoFit();
                    xCellApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                xCellApp.Quit();
            }
        }
