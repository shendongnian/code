    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Person.FirstName = "John";
        Task.Factory.StartNew( () => {
            Thread.Sleep(10000);
            // ...
        });
    }
