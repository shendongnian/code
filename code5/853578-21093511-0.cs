    <ComboBox x:Name="ColumnComboBox" SelectionChanged="ColumnComboBox_SelectionChanged" IsEditable="True" Text="Default Text" FontWeight="Italic">
    	<ComboBoxItem Content="Item 1" FontStyle="Normal"/>
    </ComboBox>
    
    private void ColumnComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	ColumnComboBox.FontStyle = ColumnComboBox.SelectedItem != null ? FontStyles.Normal : FontStyles.Italic;
    }
