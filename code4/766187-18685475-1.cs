    private void Form1_Load(object sender, EventArgs e)
    {
        
        for (int i = 0; i < newOrder.menuEntree.Length; i++)
        {
            Order newOrder = new Order ();
            this.listBox.Items.Add(newOrder.menuEntree[i]);
        }
    }
