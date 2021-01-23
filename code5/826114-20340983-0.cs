    private void shuffleItemsToolStripMenuItem_Click(object sender, EventArgs e) {
       ListBox.ObjectCollection list = listBox1.Items;       
       Random rng = new Random();
       int n = list.Count;
       //begin updating
       listBox1.BeginUpdate();
       while ( n > 1 ) {
        n--;
        int k = rng.Next(n + 1);
        object value = list[k];
        list[k] = list[n];
        list[n] = value;
       }
       listBox1.EndUpdate();
       listBox1.Invalidate();
    }
