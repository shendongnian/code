    String msg="";
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        string value = dataGridView1.CurrentCell.Value.ToString();
        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ColumnName"].Value = trapInputs(value);
        MessageBox.Show(msg);
    }
    public void trapInputs(string value)
    {
        DateTime val = DateTime.Now;
                try
                {
                    val = Convert.ToDateTime(value);
                }
                catch
                {
                    if (value.Split('/').Length == 3)
                    {
                        string[] arr = value.Split('/');
                        try
                        {
                            if (Convert.ToInt32(arr[1]) > Convert.ToInt32(arr[0]))
                            {
                                val = Convert.ToDateTime(arr[1] + "/" + arr[0] + "/" + arr[2]);
                            }
                        }
                        catch
                        {
                            msg = "Invalid date.";
                        }
                    }
                    else if(value.Split('-').Length==3)
                    {
                        string[] arr = value.Split('-');
                        try
                        {
                            if (Convert.ToInt32(arr[1]) > Convert.ToInt32(arr[0]))
                            {
                                val = Convert.ToDateTime(arr[1] + "-" + arr[0] + "-" + arr[2]);
                            }
                        }
                        catch
                        {
                            msg = "Invalid date.";
                        }
                    }
                    else
                    {
                        msg = "Invalid date.";
                    }
                }
                value = String.Format("{0:yyyy-MM-dd}", val);
    }
