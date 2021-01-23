    public async void buttonTest()
    {
        await readFiles();
        Deployment.Current.Dispatcher.BeginInvoke(() =>
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
