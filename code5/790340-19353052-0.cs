     <Button Command="{Binding Path=DataContext.DeleteItemCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListBox}}}"
             CommandParameter="{Binding}" />
    public MainWindow()
    {
        InitializeComponent();
        DeleteItemCommand = new RelayCommand(person => DeletePerson(person as Person));
    }
    private void DeletePerson(Person person)
    {
        Collection.Remove(person);
    }
