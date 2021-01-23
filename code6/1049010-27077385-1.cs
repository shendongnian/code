    public class FooLisBox : System.Windows.Forms.ListBox
    {
        public void RefreshAllItems()
        {
            RefreshItems();
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
       (listBox1.Items[0] as ShipListBoxItem).Ship.Name = "AAAA";
       listBox1.RefreshAllItems();
    }
