    void Main_Load(object sender, EventArgs e)
    {
         listBox.View = View.Details;
         listBox.Columns.Add("Ingredients", 100, HorizontalAlignment.Center);
         listBox.Columns.Add("Amount", 100, HorizontalAlignment.Center);
         listBox.Columns.Add("Cost", 100, HorizontalAlignment.Center);
    }
    
    void _btnAddIngredients(object sender, MouseEventArgs e)
    {
         listBox.Items.Add("Add Text Here");
    }
