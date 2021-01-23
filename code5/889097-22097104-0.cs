    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox comboBox = e.Control as ComboBox;
        if (comboBox != null)
        {
            comboBox.Enter -= comboBox_Enter;
            comboBox.Enter += comboBox_Enter;
        }
    }
    private void comboBox_Enter(object sender, EventArgs e)
    {
        ((ComboBox)sender).DroppedDown = true;
    }
