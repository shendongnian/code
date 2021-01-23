    private void BtnUncheckAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < checkBoxList.Items.Count; i++)
        {
            checkBoxList.SetItemChecked(i, false);
        }
    }
