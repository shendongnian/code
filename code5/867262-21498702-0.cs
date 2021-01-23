    public class MyComboBox : ComboBox
    {
        static MyComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyComboBox),
                               new FrameworkPropertyMetadata(typeof(MyComboBox)));
        }
    }
