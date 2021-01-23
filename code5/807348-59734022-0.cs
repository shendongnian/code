xaml
<xctk:CheckListBox 
	ItemsSource="{Binding AllItems}"
	DisplayMemberPath="Display"
	ValueMemberPath="Value" 
	SelectedItemsOverride="{Binding Path=DataContext.SelectedItems, RelativeSource={RelativeSource FindAncestor, AncestorType=Window}, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
</xctk:CheckListBox>
Code in ViewModel:
c#
public IEnumerable<Item> AllItems { get; set; }
public ObservableCollection<Item> SelectedItems { get; set; }
public ViewModel()
{
	SelectedItems = new ObservableCollection<Item>();
	SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
}
private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
	// Handle collection changed event
}
