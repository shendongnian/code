    lines.SelectedIndex = 0;
    lines.SelectedItem = param.Component.Attributes.Items;// This items contains 1000000,3 00000, and so on.
    
    lines.SelectionChanged += (o,e) => {
        MessageBox.Show("clist   _SelectionChanged1");
        txtblk1ShowStatus.Text = lines.SelectedItem.ToString();
    };
    
    lines.SelectedIndex = lines.Items.Count - 1;
