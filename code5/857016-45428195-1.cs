    DataGridViewButtonColumn button = new DataGridViewButtonColumn() // no semi-colon
    {
        button.Name = "button";
        button.HeaderText = "Button";
        button.Text = "Button";
        button.UseColumnTextForButtonValue = true; //dont forget this line
        this.dataGridView1.Columns.Add(button);
    }
