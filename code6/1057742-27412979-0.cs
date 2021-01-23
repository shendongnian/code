    private static async void SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Selector selector = (Selector)sender;
        if (selector != null)
        {
             ICommand command = selector.GetValue(CommandProperty) as ICommand;
             if (command != null)
             {
                 await Task.Run(() => command.Execute(selector.SelectedItem));
             }
        }
    }
