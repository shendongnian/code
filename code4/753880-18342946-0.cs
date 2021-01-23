    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        // start with Bread and change if necessary.
        List<Product> products = Bread;
        if (comboBox1.Items.IndexOf(comboBox1.SelectedItem) == 0)
        {
            //change the value of "products"
            products = Drinks;
        }
        foreach (Product item in products)
        {
            listBox1.Items.Add(item.ProductName + item.Price);
        }
    }
