    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox c = e.Control as ComboBox;
            if (c != null)
            {
                c.DropDownStyle = ComboBoxStyle.DropDown;
                c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                c.MaxDropDownItems = 100;
                c.KeyPress += new KeyPressEventHandler(c_KeyPress);
            }
        }
    void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            (sender as ComboBox).DroppedDown = false;
        }
