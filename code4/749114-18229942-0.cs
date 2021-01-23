    {
        var selectRow = GridEquipmentChechList.MyGridView.SelectedRow;
        if (selectRow != null)
        {
            txtECNumber.Text = selectRow.Cells[1].Text;
            **ddEquipmentName.SelectedIndex = ddEquipmentName.Items.IndexOf(ddEquipmentName.Items.FindByText(selectRow.Cells[2].Text));**
            **ddDescription.SelectedIndex = ddDescription.Items.IndexOf(ddDescription.Items.FindByText(selectRow.Cells[3].Text));**
        }
    }
