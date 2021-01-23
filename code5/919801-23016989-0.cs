    public class ValidTextBox : TextBox
    {
        public ValidTextBox()
        {
            LostFocus += ValidTextBox_LostFocus;
        }
        void ValidTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO validate
        }
    }
