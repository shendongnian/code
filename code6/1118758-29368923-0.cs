        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.IsReadOnly = false;
            textBox.Background = new SolidColorBrush(Colors.White);
            textBox.Foreground = new SolidColorBrush(Colors.Black);
        }
