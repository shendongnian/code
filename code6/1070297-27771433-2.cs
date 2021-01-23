       public static void CreateAndSubscribe(this displayCommand)
        {
            displayCommand = ReactiveCommand.Create();
            displayCommand.Subscribe(_ =>
            {
                MessageBox.Show("Button clicked.");
            });
        }
