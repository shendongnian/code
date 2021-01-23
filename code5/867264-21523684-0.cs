    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            SetResourceReference(Control.StyleProperty, typeof(ComboBox));
        }
    }
