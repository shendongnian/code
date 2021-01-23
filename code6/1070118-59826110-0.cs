    //Load sample data
    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = Enumerable.Range(1, 5)
            .Select(x => new { Name = $"Product {x}", Id = x }).ToList();
        comboBox1.DisplayMember = "Name";
        comboBox1.ValueMember = "Id";
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //Knows value
        var value = 3;
        //Find item based on value
        var item = comboBox1.Items.Cast<Object>()
            .Where(x => (int)comboBox1.GetItemValue(x) == value)
            .FirstOrDefault();
        //Find index 
        var index = comboBox1.Items.IndexOf(item);
        //Set selected index
        comboBox1.SelectedIndex = index;
    }
