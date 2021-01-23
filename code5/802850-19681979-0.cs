    public class CustomTextBox : TextBox
    {
        public static readonly DependencyProperty OperationProperty = 
            DependencyProperty.Register(
                "Operation", //property name
                typeof(string), //property type
                typeof(CustomTextBox), //owner type
                new FrameworkPropertyMetadata("Default value")
            );
        public string Operation
        {
            get
            {
                return (string)GetValue(OperationProperty);
            }
            set
            {
                SetValue(OperationProperty, value);
            }
        }
    }
