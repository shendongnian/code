    BindingList<customers> table1List;
    BindingList<customers> table2List;
    public FormWith2Listboxes()
    {
        InitializeComponent();
        table1List = new BindingList<customers>();
        table1List.Add(new customers() { id = 1, name = "name1" });
        table1List.Add(new customers() { id = 2, name = "name2" });
        table1List.Add(new customers() { id = 3, name = "name3" });
        table2List = new BindingList<customers>();
        table2List.Add(new customers() { id = 4, name = "name4" });
        this.table1Box.DataSource = this.table1List;
        this.table2Box.DataSource = this.table2List;
    }
    private void table1ToTable2Button_Click(object sender, EventArgs e)
    {
        foreach (int i in this.table1Box.SelectedIndices)
        {
            var selectedCustomer = (customers)this.table1Box.Items[i];
            table2List.Add(selectedCustomer);
            table1List.Remove(selectedCustomer);
        }
    }
