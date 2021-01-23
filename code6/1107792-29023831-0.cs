    internal class MyButton : Button
    {
        public MyButton()
        {
            this.Loaded += MyButton_Loaded;
        }
        private void MyButton_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!App.IsInDesignMode)
            {
                var controller = App.kernel.Get<ICommand>("SomeCommand");
                this.CommandParameter = Tag;
                this.Command = controller;
            }
        }
    }
