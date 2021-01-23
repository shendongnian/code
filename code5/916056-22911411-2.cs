    public class CustomLabel : Label
    {
        public static readonly DependencyProperty StrProperty = 
                               DependencyProperty.Register("Str",
                                                           typeof(string),
                                                           typeof(CustomLabel), 
                                                           new UIPropertyMetadata(String.Empty, IsStrTurn));
        public string Str
        {
            get
            {
                return GetValue(StrProperty) as string; 
            }
            set
            {
                SetValue(StrProperty, value);
            }
        }
        private static void IsStrTurn(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {    
            string strOld = e.OldValue as string;
            string strNew = e.NewValue as string;
            System.Diagnostics.Debug.WriteLine("The old value is " + strOld); // The old value is "init"
            System.Diagnostics.Debug.WriteLine("The new value is " + strNew); // The new value is "blub"
        }
    }
