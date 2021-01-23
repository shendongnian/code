        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var memberName = reader[0].ToString();
            var lbl = new Label();
            Controls.Add(lbl); 
            lbl.Text = memberName;
        }
