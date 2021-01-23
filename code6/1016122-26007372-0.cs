    class Screen
    {
        Keyboard keyboard;
        public Screen()
        {
            //pass the screen instance to the keyboard
            keyboard = new Keyboard(this);
        }
        //...
        private void TextBoxPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBox = sender as TextBox;
            textBox.Focus();
            //open keyboard etc
            keyboard.Show();
        }
    }
    class Keyboard
    {
        private Screen screenInstance;
        public Keyboard(Screen instance)
        {
            //store the instance in a member variable
            screenInstance = instance;
        }
        //...
        private void button_numeric_1_Click(object sender, RoutedEventArgs e)
        {
            //use the stored screen instance
            screenInstance.textBox.Text += "1";
        }
        public void Show()
        {
            //display logic etc
        }
    }
