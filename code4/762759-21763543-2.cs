    <toolkit:ListPicker Name="picker" SelectionChanged="OnSelectionChanged">
        <toolkit:ListPickerItem Content="Bid" Tag="{x:Static local:Side.Bid}" />
        <toolkit:ListPickerItem Content="Ask" Tag="{x:Static local:Side.Ask}" />
    </toolkit:ListPicker>
    void OnSelectionChanged(...)
    {
        if (DataContext != null && picker.SelectedItem != null)
           (DataContext as MyClass).Side= (Side)(((ListPickerItem)picker.SelectedItem).Tag);
    }
    
    void Init()
    {
        picker.SelectedItem = picker.Items.First(i => (DataContext as MyClass).Side.Equals(((ListPickerItem)i).Tag));
    }
