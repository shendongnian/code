    <Button Content="Close Tab" Command="{Binding CloseTabCommand}" 
        CommandParameter="{Binding}" />
    ...
 
    public ICommand CloseTabCommand
    {
        get { return new ActionCommand(action => Items.Remove(action), 
            canExecute => canExecute != null && Items.Contains(canExecute)); }
    }
