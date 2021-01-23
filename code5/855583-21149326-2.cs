    public class CustomDataGridComboBoxColumn : DataGridComboBoxColumn
    {
        public override object OnCopyingCellClipboardContent(object item)
        {
            if (item as ComboboxPair<float> is null)
                return null;
            return ((ComboboxPair<float>)item).Key;
        }
    }
