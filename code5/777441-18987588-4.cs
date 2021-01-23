    string editingText;
    int editingRowIndex = -1;
    private void textBox_TextChanged(object sender, EventArgs e)
    {
        editingRowIndex = ((DataGridViewTextBoxEditingControl)sender).EditingControlRowIndex;
        editingText = (sender as Control).Text;
        UpdateText();
    }
    private void UpdateText()
    {
        foreach (DataGridViewRow row in m_languageGrid.Rows)
        {
            if (row.Cells[1].Value != null)
            {
                string text = row.Index == editingRowIndex ?
                              editingText : row.Cells[1].Value.ToString();
                System.Diagnostics.Debug.WriteLine(text);
            }
        }
    }
