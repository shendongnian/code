    public static string ShowDialog(int columnnumber, string columnname)
    {
        Form prompt = new Form();
        prompt.Width = 500;
        prompt.Height = 150;
        prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
        prompt.Text = columnname;
        prompt.StartPosition = FormStartPosition.CenterScreen;
        Label textLabel = new Label()
        {
            Left = 50,
            Top = 20
        };
        ComboBox comboBox = new ComboBox()
        {
            Left = 50,
            Top = 50,
            Width = 400
        };
        comboBox.Items.AddRange(new string[] { "a", "b", "c" });
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox.SelectedItem = columnname;
        Button confirmation = new Button()
        {
            Text = "Ok",
            Left = 350,
            Width = 100,
            Top = 80
        };
        bool confirmed = false;
        confirmation.Click += (sender, e) =>
        {
            prompt.Close();
            confirmed = true;
        };
        textLabel.Text = "Colonne " + (columnnumber + 1).ToString() + " : " + columnname;
        prompt.Controls.Add(comboBox);
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;
        prompt.ShowDialog();
        prompt.AcceptButton = confirmation;
        return confirmed ? comboBox.Text : null;
    }
