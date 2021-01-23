    public class PosTextBox : TextBox
    {
        public static readonly DependencyProperty PosTypeProperty =
            DependencyProperty.Register("PosType", typeof (string), typeof (PosTextBox), new PropertyMetadata(default(string)));
        public string PosType
        {
            get { return (string)GetValue(PosTypeProperty); }
            set { SetValue(PosTypeProperty, value); }
        }
    }
