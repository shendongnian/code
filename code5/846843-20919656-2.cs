    public class MyComboBox : ComboBox
    {
        protected override void OnItemsSourceChanged(IEnumerable oldValue,
                                                     IEnumerable newValue)
        {
            if (newValue != null && 
                newValue.GetType().Equals(typeof(EnumSource.EnumMember[])))
            {
                SelectedValuePath = "Value";
            }
            base.OnItemsSourceChanged(oldValue, newValue);
        }
    }
