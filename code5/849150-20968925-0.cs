    public ICommand SaveCommand
    {
        get { return new RelayCommand(execute => Save(), canExecute => CanSave()); }
    }
    ...
    <Button Content="Save" Command="{Binding SaveCommand}" />
