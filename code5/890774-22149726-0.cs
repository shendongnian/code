    void ExtendedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!chk_IsChanging)
                this.IsCheckedReal = "X";                      
        }
        public string IsCheckedReal
        {
            get { return (string)GetValue(IsCheckedRealProperty); }
            set
            {
                SetValue(IsCheckedRealProperty, value);
            }
        }
        public static readonly DependencyProperty IsCheckedRealProperty =
            DependencyProperty.Register("IsCheckedReal", typeof(string), typeof(ExtendedCheckBox), new PropertyMetadata(IsCheckedRealChanged));
        private static void IsCheckedRealChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            
            if (e.NewValue.Equals("X") || e.NewValue.Equals("Y"))
            {
                ((ExtendedCheckBox)o).IsChecked = true;
            }
            else if (e.NewValue.Equals("") || e.NewValue.Equals("N"))
            {
                ((ExtendedCheckBox)o).IsChecked = false;
            }
            
        }
