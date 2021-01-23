    SqlDataReader sqlReader = controll.GetData();
            while (sqlReader.Read())
            {
                infTxtBox.Text = sqlReader.ToString();
            }
    
    control.CloseConnection();
