    public static class MahappsHelper
    {
        /// <summary>
        /// Attach Caliburn cal:Message.Attach for the Mahapps TextBoxHelper.Button
        /// </summary>
        public static readonly DependencyProperty ButtonMessageProperty =
            DependencyProperty.RegisterAttached("ButtonMessage", typeof(string), typeof(MahappsHelper), new PropertyMetadata(null, ButtonMessageChanged));
        public static string GetButtonMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(ButtonMessageProperty);
        }
        public static void SetButtonMessage(DependencyObject obj, string value)
        {
            obj.SetValue(ButtonMessageProperty, value);
        }
        private static void ButtonMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement textBox = d as TextBox;
            if (d == null)
                textBox = d as PasswordBox;
            if (d == null)
                textBox = d as ComboBox;
            if (textBox == null)
                throw new ArgumentException("ButtonMessage does not work with control " + d.GetType());
            textBox.Loaded -= ButtonMessageTextBox_Loaded;
            Button button = GetTextBoxButton(textBox);
            if (button != null)
            {
                SetButtonMessage(textBox, button);
                return;
            }
            // cannot get button, try it in the Loaded event
            textBox.Loaded += ButtonMessageTextBox_Loaded;
        }
        private static Button GetTextBoxButton(FrameworkElement textBox)
        {
            return TreeHelper.FindChild<Button>(textBox, "PART_ClearText");
        }
        private static void ButtonMessageTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement textBox = (FrameworkElement)sender;
            textBox.Loaded -= ButtonMessageTextBox_Loaded;
            Button button = GetTextBoxButton(textBox);
            SetButtonMessage(textBox, button);
        }
        /// <summary>
        /// Set Caliburn Message to the TextBox button.
        /// </summary>
        private static void SetButtonMessage(FrameworkElement textBox, Button button)
        {
            if (button == null)
                return;
            string message = GetButtonMessage(textBox);
            Caliburn.Micro.Message.SetAttach(button, message);
        }
    }
