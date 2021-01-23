    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.CurrentRow.Cells["Id"].Value != null)
                {
                    int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    SqlConnection con = new SqlConnection(Connection);
                    SqlCommand Cmd = new SqlCommand("select emp_id,emp_name,DOB,Occupation,Salary  from tbl_Emp where emp_id=" + Id + "",con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int idx = dataGridView2.Rows.Count-1;
                        dataGridView2.Rows.Add(dt.Rows.Count);
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            int rVal = (idx + i) + 1;
                            dataGridView2.Rows[rVal].Cells["EmpId"].Value = dt.Rows[i]["emp_id"].ToString();
                            dataGridView2.Rows[rVal].Cells["EmpName"].Value = dt.Rows[i]["emp_name"].ToString();
                            dataGridView2.Rows[rVal].Cells["DOB"].Value = dt.Rows[i]["DOB"].ToString();
                            dataGridView2.Rows[rVal].Cells["Occupation"].Value = dt.Rows[i]["Occupation"].ToString();
                            dataGridView2.Rows[rVal].Cells["Salary"].Value = dt.Rows[i]["Salary"].ToString();
                        }
    
                    }
                    con.Close();
                }
            }
