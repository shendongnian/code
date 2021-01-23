    DataTable dt=new DataTable();
            dt.Load(reader);
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                {
                    if (i == 0)
                    {
                        c1 = dt.Rows[i]["Firstname "].ToString();
                        radioButton1.Text = c1;
                    }
                    if (index == 1)
                    {
                        c1 = dt.Rows[i]["Firstname "].ToString();
                        radioButton2.Text = c1;
                    }
                    ..
                    MessageBox.Show("c1  :" + c1);
                   
                }
