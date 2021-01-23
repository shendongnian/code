    void Main_Load(object sender, EventArgs e)
    {
         listView.View = View.Details;
         listView.Columns.Add("Ingredients", 100, HorizontalAlignment.Center);
         listView.Columns.Add("Amount", 100, HorizontalAlignment.Center);
         listView.Columns.Add("Cost", 100, HorizontalAlignment.Center);
    }
    
    void _btnAddIngredients(object sender, MouseEventArgs e)
    {
         listView.Items.Add("Add Text Here");
    }
