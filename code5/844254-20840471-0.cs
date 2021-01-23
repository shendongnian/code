    string str="Select km from tablename;
                SqlDataAdapter ad = new SqlDataAdapter(str,connection object);
                DataSet ds = new DataSet();
                ad.Fill(ds);
         
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Textbox1.Text = ds.Tables[0].Rows[0][0].ToString();
                }
