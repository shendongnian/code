    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable tb = new DataTable();
        tb.Columns.Add("Value");
        tb.Rows.Add("Combo Box Item");
        cb.DisplayMember = "Value";
        cb.ValueMember = "Value";
        cb.DataSource = tb;
        cb.Text = "Select Something";
    }
