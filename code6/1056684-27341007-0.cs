           SqlDataReader dr = SQL.queryExec("SELECT * FROM tables");            
           int i = 0;
            while (dr.Read())
            {
                Button btn = new Button();
                btn.Text = dr["tbl_Name"].ToString();
                btn.Width = 100;
                btn.Height = 50;
                btn.Left = (i % 5) * 110;
                btn.Top = (i / 5) * 60;
                Controls.Add(btn);
                i++;
            }
