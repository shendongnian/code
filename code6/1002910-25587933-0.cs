    private void SelectedPreset(object sender, EventArgs e)
            {
                var p = productList.Where(x => x.Name == (sender as ToolStripMenuItem).Text).Single();
    
                label2.Text = "Product Category: " + (sender as ToolStripMenuItem).Text;
                label3.Text = "Product Price: " + p.Price;
            }
