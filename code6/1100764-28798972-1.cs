    int index = cboSection.FindString(row.Cells["section"].Value.ToString());
    if(index > -1)
    {
       cboSection.SelectedIndex = index;
    }
    else
    {
            object newSection = row.Cells["section"].Value.ToString();
            cboSection.Items.Add(newSection);
            cboSection.SelectedItem = newSection;
    }
