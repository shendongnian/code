       private void ListBox5_Click(object sender, System.EventArgs e) {
        ListBox lb = new ListBox();
        lb = (ListBox)sender;
        if ((lb.SelectedIndex != -1)) {
            ListBox1.SelectedIndex = lb.SelectedIndex;
            ListBox2.SelectedIndex = lb.SelectedIndex;
            ListBox3.SelectedIndex = lb.SelectedIndex;
            ListBox4.SelectedIndex = lb.SelectedIndex;
            ListBox5.SelectedIndex = lb.SelectedIndex;
            txtsn.Text = ListBox1.SelectedItem;
            txtsa.Text = ListBox2.SelectedItem;
            txtsadd.Text = ListBox3.SelectedItem;
            txtsp.Text = ListBox4.SelectedItem;
            txtse.Text = ListBox5.SelectedItem;
        }
    }
