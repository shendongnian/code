       public static void CreateAndSubscribe(this ReactiveCommand<object> displayCommand)
        {
            displayCommand.ReactiveCommand.Create();
            displayCommand.Subscribe(_ =>
            {
                MessageBox.Show("Button clicked.");
            });
        }
