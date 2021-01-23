                SqlCommand cmd1 = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cn.Open();
                cmd1.CommandText = "select *  from userinfo where "' where username ='" + userName + "' and password ='" + password + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = cn;
                da.SelectCommand = cmd1;
                da.Fill(ds, "userinfo ");
                if (ds.Tables["userinfo "].Rows.Count > 0)
                {
                    TextBox3.Text = ds.Tables["userinfo "].Rows[0].ItemArray[1].ToString();
                }
