    public class Payment : DependencyObject
    {
        public static readonly DependencyProperty ValidationStringProperty =
                 DependencyProperty.Register("ValidationString", typeof(string), typeof(Payment), new PropertyMetadata(new PropertyChangedCallback(OnValidationStringChanged)));
        public string ValidationString
        {
            get { return (string)this.GetValue(Payment.ValidationStringProperty); }
            set
            {
                this.SetValue(Payment.ValidationStringProperty, value);
            }
        }
    
    	private static void OnValidationStringChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // do stuff all that stuff you wanted to do ValidationString
        }
    }
