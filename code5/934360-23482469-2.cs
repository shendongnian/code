    private void ItemInfo_Load(object sender, EventArgs e)
    {
        this.inspectorTableAdapter.Fill(this.someDBDataSet.inspector);
        this.itemTableAdapter.Fill(this.someDBDataSet.item);
    }
    private void noInspector_btn_Click(object sender, EventArgs e)
    {
        inspector_idComboBox.SelectedItem = null;
    }
