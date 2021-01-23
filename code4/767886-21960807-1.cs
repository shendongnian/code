    if (dataGridView1.CurrentCell == dataGridView1.CurrentRow.Cells["article_name"])
                    {
                        string CategoryValue = "";
                        //string CategoryValue1 = "";
    
                        if (dataGridView1.CurrentCell.Value != null)
                        {
                            CategoryValue = dataGridView1.CurrentCell.Value.ToString();
                            //CategoryValue1 = dataGridView1.CurrentCell.Value.ToString();
                        }
                        //SqlConnection objCon = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=dbTest3;Integrated Security=True");
                        string query = "select article_name,composition from Setup_article_custominvoice where article_name='" + CategoryValue + "'";
                        SqlCommand objCmd = new SqlCommand(query, con);
    
                        SqlDataAdapter objDA = new SqlDataAdapter(objCmd);
    
                        objDA.SelectCommand.CommandText = objCmd.CommandText.ToString();
                        DataTable dt = new DataTable();
    
                        objDA.Fill(dt);
    
                        DataGridViewComboBoxCell t = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2] as DataGridViewComboBoxCell;
                        t.DataSource = dt;
                        t.DisplayMember = "composition";
                        
                    }
