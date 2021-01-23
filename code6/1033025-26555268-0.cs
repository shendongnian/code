    private void PopulateList(ComboBox boxToPopulate, List<String> selectionList)
    {
        object[] comboBoxList1 = new object[selectionList.Count];
        int i = 0;
        foreach (Selection s in selectionList)
        {
            string description = s.Description;
            comboBoxList1[i] = description;
            i++;
        }
        boxToPopulate.Items.AddRange(comboBoxList1);
    }
