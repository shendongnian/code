    class MyClass
    {
        public int Organization_ID{ get; set; }
        public string Organization_Names{ get; set; }
    }
    <controls:AutoCompleteBox x:Name="autoCompleteBox1"    
          SelectionChanged="autoCompleteBox1_SelectionChanged"      
          FilterMode="Contains"              
          IsTextCompletionEnabled="True">
        <controls:AutoCompleteBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Organization_Names}" />
            </DataTemplate>
        </controls:AutoCompleteBox.ItemTemplate>
    </controls:AutoCompleteBox>
    private void autoCompleteBox1_SelectionChanged(object sender, RoutedEventArgs e)
    {
       MessageBox.Show(((MyClass)autoCompleteBox1.SelectedItem).Organization_ID);
    }
