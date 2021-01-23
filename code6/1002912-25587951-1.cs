            private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
                Product p = productList.Find(i => i.Name == e.ClickedItem.Text);
                //just in case its null...
                if(p != null)
                {
                   label1.Text = "Product Name: " + p.Name;
                   label2.Text = "Product Category: " + p.Category;
                   label3.Text = "Product Price: " + p.Price;
                }
            }
