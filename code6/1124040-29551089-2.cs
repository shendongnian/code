    public async void buttonTest()
    {
        await readFiles();
        CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            foreach (string name in z.test)
            {
                Button button1 = new Button();
                button1.Height = 75;
                button1.Content = name;
                button1.Name = name;
                testStackPanal.Children.Add(button1);
            }
        });
    }
