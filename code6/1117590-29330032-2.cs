     <StackPanel>        
        <DataGrid x:Name="DG_Reports" Height="200"
                AutoGenerateColumns="False"                
                ItemsSource="{Binding SampleItems}" >
            <DataGrid.RowHeaderTemplate>
                <DataTemplate>
                    <Grid>
                        <CheckBox IsChecked="{Binding Path=IsSelected, Mode=TwoWay,
                            RelativeSource={RelativeSource FindAncestor,AncestorType={x:Type DataGridRow}}}"/>
                    </Grid>
                </DataTemplate>
            </DataGrid.RowHeaderTemplate>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Date" Binding="{Binding DayOfMonth}">                   
                </DataGridTextColumn>
                <DataGridTextColumn Header="Day" Binding="{Binding Weekday}">                    
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
        <Button x:Name="Bt_RemoveReports" Content="Supprimer Rapport" Command="{Binding DeleteReports}"
                CommandParameter="{Binding ElementName=DG_Reports, Path=SelectedItems}">            
        </Button>
    </StackPanel>   
     public class Item
    {
        public int DayOfMonth { get; set; }
        public string Weekday { get; set; }
    }
    public class MainViewModel 
    {
        private ObservableCollection<Item> m_items;
        public ObservableCollection<Item> SampleItems
        {
            get { return m_items; }
            set { m_items=value; }
        }
        public ICommand DeleteReports { get; private set; }
        public MainViewModel()
        {
            DeleteReports = new RelayCommand<object>(Delete,CanDelete);
            var items = new ObservableCollection<Item>();
            var today = DateTime.Now;
            for (int i = 1; i <= DateTime.DaysInMonth(today.Year, today.Month); i++)
            {
                items.Add(new Item { DayOfMonth = i, Weekday = new DateTime(today.Year, today.Month, i).DayOfWeek.ToString() });
            }
            SampleItems = items;
        }
        private void Delete(object obj)
        {
            var items = new ObservableCollection<Item>();
            foreach (var item in (IList)obj)
            {
                items.Add((Item)item);
            }
            foreach (var item in items)
            {
                m_items.Remove(item);
            }
        }
        private bool CanDelete(object obj)
        {
            return ((IList)obj).Count > 0;
        }
        
    }
