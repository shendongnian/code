            while(dr.Read())
            {
             valuesList.Add(dr.GetString(0));
             valuesList.Add(dr.GetString(1));
             valuesList.Add(dr.GetString(2));
             valuesList.Add(dr.GetString(3));
            }
            dr.Close();
            Label1.Text = "works";
