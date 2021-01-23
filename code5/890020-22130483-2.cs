    List<ComputerDataGridBO> itemsToSave = new List<ComputerDataGridBO>(
        ComputerDataGridListTest.Where(c => c.IsEdited));
    if (itemsToSave != null)
    {
        // save items in itemsToSave and set their IsEdited properties to false
    }
