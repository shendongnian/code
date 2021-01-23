    public class IOViewModel
    {
        public ObservableCollection<AvailableRegister> SelectedRegisters { get; set; }
    
        private AvailableRegister _selectedRegister;
        public AvailableRegister SelectedRegister { get { return _selectedRegister; } set { _selectedRegister = value; } }
    
        public IOViewModel()
        {
            this.Registers = new ObservableCollection<AvailableRegister>();
            this.Registers.CollectionChanged += Registers_CollectionChanged;
        }
    
        void Registers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Never hit when changing combo box
        }
    }
-----
    
    <DataTemplate x:Key="ItemTemplate">
        <ComboBox SelectedItem="{Binding DataContext.SelectedItem, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=UserControl}}" ItemsSource="{Binding DataContext.AvailableRegisters, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=UserControl}, Mode=TwoWay}">
            <ComboBox.ItemTemplate>
                <DataTemplate><!-- Display it here --></DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
    </DataTemplate>
