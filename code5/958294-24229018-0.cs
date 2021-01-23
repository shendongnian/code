        if (dr["batch_no"].ToString() == dr2["batch_no"].ToString())
        {
            while (dr.Read())
            {
                string num = dr.GetString(dr.GetOrdinal("batch_no")); //dr["batch_no"].ToString();
                foreach (DataGridViewRow myrow in dataGridView1.Rows)
                {
                    if (Convert.ToString(myrow.Cells[0].Value) == num)
                    {
                        myrow.DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                    }
                }
            }
            con.Close();
            con2.Close();
        }
