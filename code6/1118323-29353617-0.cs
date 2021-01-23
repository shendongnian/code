    public class CustomTextBox : TextBox
        {
            public CustomTextBox()
            {
                KeyDown += OnKeyDown;
            }
        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                    keyEventArgs.Handled = false;
                    break;
                default:
                    keyEventArgs.Handled = true;
                    break;
            }
        }
    }
