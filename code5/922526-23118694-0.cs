     try
            {
                conn.Open();
                string myquery = "SELECT ISNULL(IGP_CODE,0) FROM TBL_IGP_HEADER";
                SqlCommand comd = new SqlCommand(myquery, conn);
                comd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string values = dt.Rows.Count.ToString();
                if (values == null)
                {
                    textIGPNo.Text = values;
                }
                else
                {
                    string myquery1 = "SELECT IGP_CODE FROM TBL_IGP_HEADER";
                    SqlCommand cmd = new SqlCommand(myquery1, conn);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    DataTable dts = new DataTable();
                    daa.Fill(dts);
                    int value = dt.Rows.Count;
                    int nvalue = value + 1;
                    textIGPNo.Text = nvalue.ToString();
                }
           }
       catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
