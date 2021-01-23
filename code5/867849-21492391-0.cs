    foreach (object itemChecked in cListBoxSubKeys.CheckedItems)
    {
        var uniqueId = itemChecked.GetType().GetProperty("ID").GetValue(itemChecked, null);
        Registry.LocalMachine.DeleteSubKey(subKey + "\\" + uniqueId);
    }
