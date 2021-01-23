    <DataGrid HorizontalAlignment="Left" AutoGenerateColumns="False" ItemsSource="{Binding Items}" Margin="67,70,0,0" VerticalAlignment="Top" Height="170" Width="388">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Raw Materials" Width="*" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock VerticalAlignment="Center" Text="{Binding Path=SelectedRawMaterials.Display,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox DisplayMemberPath="Display" SelectedItem="{Binding Path=SelectedRawMaterials,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" SelectedValuePath="Value" ItemsSource="{Binding RMColloction}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Raw Materials" Width="*">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock VerticalAlignment="Center" Text="{Binding Path=SelectedSize.Display}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <ComboBox DisplayMemberPath="Display" SelectedItem="{Binding Path=SelectedSize}" SelectedValuePath="Value" ItemsSource="{Binding SizeFiltered}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
     public class Item:INotifyPropertyChanged
    {
        public ICollectionView SizeFiltered { get; set; }
        public Item()
        {
            RMColloction = new ObservableCollection<RawMaterials>();
            RMColloction.Add(new RawMaterials() { Display = "RM1", Value = 1 });
            RMColloction.Add(new RawMaterials() { Display = "RM2", Value = 2 });
            RMColloction.Add(new RawMaterials() { Display = "RM3", Value = 3 });
            RMColloction.Add(new RawMaterials() { Display = "RM4", Value = 4 });
            RMColloction.Add(new RawMaterials() { Display = "RM5", Value = 5 });
            RMColloction.Add(new RawMaterials() { Display = "RM6", Value = 6 });
            SizeColloction = new ObservableCollection<Size>();
            SizeColloction.Add(new Size() { Display = "A", Value = 1, RMId = 1 });
            SizeColloction.Add(new Size() { Display = "B", Value = 2, RMId = 2 });
            SizeColloction.Add(new Size() { Display = "C", Value = 3, RMId = 2 });
            SizeColloction.Add(new Size() { Display = "D", Value = 4, RMId = 1 });
            SizeColloction.Add(new Size() { Display = "E", Value = 5, RMId = 2 });
            SizeColloction.Add(new Size() { Display = "F", Value = 6, RMId = 1 });
            SizeFiltered = new CollectionViewSource { Source = SizeColloction }.View;
            SizeFiltered.Filter = RmFilter;
        }
        private bool RmFilter(object item)
        {
            bool filter=false;
            if (SelectedRawMaterials != null)
            {
                if ((((Size)item).RMId == SelectedRawMaterials.Value))
                    filter= true;
                else
                    filter= false;
            }
            return filter;
        }
        public ObservableCollection<RawMaterials> RMColloction { get; set; }
        public ObservableCollection<Size> SizeColloction { get; set; }       
        private RawMaterials selectedRawMaterials;
        public RawMaterials SelectedRawMaterials
        {
            get { return selectedRawMaterials; }
            set 
            { 
                selectedRawMaterials = value;
                OnPropertyChanged("SelectedRawMaterials");
                SizeFiltered.Refresh();
            }
        }   
        
        public Size SelectedSize { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }    
