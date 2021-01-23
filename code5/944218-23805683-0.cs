    private async void OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        PopupMenu menu1 = new PopupMenu();
        menu1.Commands.Add(new UICommand("menu1 A", (function) => { }));
        menu1.Commands.Add(new UICommand("menu1 B", (function) => { }));
        Task<IUICommand> task1 = menu1.ShowAsync(new Point(100, 100)).AsTask<IUICommand>();
        PopupMenu menu2 = new PopupMenu();
        menu2.Commands.Add(new UICommand("menu2 C", (function) => { }));
        menu2.Commands.Add(new UICommand("menu2 D", (function) => { }));
        Task<IUICommand> task2 = menu2.ShowAsync(new Point(200, 100)).AsTask<IUICommand>(); // A first chance exception of type 'System.UnauthorizedAccessException' occurred in mscorlib.dll
        Task<IUICommand> task = await Task.WhenAny(task1, task2);
        var res = await task;
        if (res != null)
        {
            await new MessageDialog(res.Label).ShowAsync();
        }
        await Task.WaitAll(task1, task2); // just to await them all
    }
