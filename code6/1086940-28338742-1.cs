    MySqlDataReader dr = cmd.ExecuteReader();
    for (int i = 0; dr.Read(); i++)
    {
        Label NewLabel = new Label();
        NewLabel.ID = dr.GetString(0);
        NewLabel.Text = dr.GetString(1);
        this.pnlInfo.Controls.Add(NewLabel);
        this.pnlInfo.Controls.Add(new Literal() { Text = System.Environment.NewLine }); //here
    }
