    int index = cboSection.FindString(row.Cells["section"].Value.ToString());
    if(index > -1)
    {
       cboSection.SelectedIndex = index;
    }
    else
    {
            ComboBoxItem newSection = new ComboBoxItem();
            cboSection.Items.Add(newSection);
            cboSection.SelectedItem = newSection;
    }
