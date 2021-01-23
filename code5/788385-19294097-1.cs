    private void PopulateListBox<TEnum>(ListBox listBox, bool clearBeforeFill, int selIndex) where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("T must be an enum type");
        if(clearBeforeFill) listBox.Items.Clear();
        listBox.Items.AddRange(Enum.GetNames(typeof(TEnum))); // or listBox.Items.AddRange(Enum.GetValues(typeof(TEnum)).Cast<object>().ToArray());
        if(selIndex >= listBox.Items.Count)
            throw new ArgumentException("SelectedIndex must be lower than ListBox.Items.Count");
        listBox.SelectedIndex = selIndex;
    }
