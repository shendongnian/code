       private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                for (int it = e.Index+1; it < this.checkedListBox1.Items.Count; it++)
                {
                    this.checkedListBox1.SetItemChecked(it, false);
                }
            }
            if (e.NewValue == CheckState.Checked)
            {
                for (int it = e.Index+1; it < this.checkedListBox1.Items.Count; it++)
                {
                    this.checkedListBox1.SetItemChecked(it, true);
                }
            }
        }
