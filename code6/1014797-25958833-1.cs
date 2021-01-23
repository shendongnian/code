    private void lv_files_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
        {
            string data = "";
            foreach (ListViewItem lvi in lv_files.Items)  data += lvi.Text + "\v";
            Clipboard.SetData(DataFormats.Text, data); ;
            e.Handled = true;
        }
    }
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
        {
            string data = Clipboard.GetData(DataFormats.Text).ToString();
            var parts = data.Split('\v');
            foreach (string p in parts) textBox1.Text += p + "\r\n";
            Clipboard.Clear();
            e.Handled = true;
        }
    }
