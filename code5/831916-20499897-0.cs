    private void doWork()
    {
        // Name changed to avoid it being a keyword
        MyClass clazz = new MyClass();
        clazz.StatusChanged += (sender, args) => {
            string message = (string) sender; // This is odd
            Action action = () => textBox.Text = message;
            Dispatcher.Invoke(action);
        };
        clazz.DoStuff();
    }
