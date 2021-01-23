            private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
            {
                if(contextMenuStrip1.Items.Count > 0)
                contextMenuStrip1.Items.Clear();
    
                foreach (var p in productList)
                {
                    var itemName = p.Name;
                    contextMenuStrip1.Items.Add(itemName);
                }
                e.Cancel = false;
            }
