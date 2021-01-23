     <DataGrid x:Name="TheGrid" CanUserAddRows="True" ContextMenuOpening="TheGrid_ContextMenuOpening">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Number" Binding="{Binding}"/>
            </DataGrid.Columns>
            <DataGrid.InputBindings>
                <KeyBinding Key="A" Command="{x:Static ApplicationCommands.New}"/>
            </DataGrid.InputBindings>
            <DataGrid.CommandBindings>                
                <CommandBinding Command="{x:Static ApplicationCommands.Paste}" CanExecute="CanPaste" Executed="Paste"/>
                <CommandBinding Command="{x:Static ApplicationCommands.Copy}" CanExecute="CanCopy" Executed="Copy"/>
                <CommandBinding Command="{x:Static ApplicationCommands.New}" CanExecute="CanAddNew" Executed="AddNew"/>
            </DataGrid.CommandBindings>
            <DataGrid.ContextMenu>
                <ContextMenu>                   
                    <MenuItem Command="{x:Static ApplicationCommands.Copy}" Header="Copy"/>
                    <MenuItem Command="{x:Static ApplicationCommands.Paste}" Header="Paste"/>
                    <MenuItem Command="{x:Static ApplicationCommands.New}" Header="New row"/>
                </ContextMenu>
            </DataGrid.ContextMenu>
        </DataGrid>
     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent(); 
            TheGrid.ItemsSource = numbers;
        }
        private void Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, string.Join(",", numbers));
        }
        private void CanCopy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CanPaste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        private void Paste(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void CanAddNew(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        private void AddNew(object sender, ExecutedRoutedEventArgs e)
        {
            numbers.Add(numbers.Count);
        }
        private readonly ICollection<int> numbers = new ObservableCollection<int>();
        private void TheGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TheGrid.Focus();
        }
    }
