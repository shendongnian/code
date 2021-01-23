    private void Form1_Load(object sender, EventArgs e)
    {
        newOrder = new Order ();
        for (int i = 0; i < newOrder.menuEntree.Length; i++)
        {
            this.listBox.Items.Add(newOrder.menuEntree[i]);
        }
    }
