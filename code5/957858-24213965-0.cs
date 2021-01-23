     public static class DisallowSpecialCharactersTextboxBehavior
        {
            public static DependencyProperty DisallowSpecialCharactersProperty =
                DependencyProperty.RegisterAttached("DisallowSpecialCharacters", typeof(bool), typeof(DisallowSpecialCharactersTextboxBehavior), new PropertyMetadata(DisallowSpecialCharactersChanged));
    
            public static void SetDisallowSpecialCharacters(TextBox textBox, bool disallow)
            {
                textBox.SetValue(DisallowSpecialCharactersProperty, disallow);
            }
    
            public static bool GetDisallowSpecialCharacters(TextBox textBox)
            {
                return (bool)textBox.GetValue(DisallowSpecialCharactersProperty);
            }
    
            private static void DisallowSpecialCharactersChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
            {
                var tb = dependencyObject as TextBox;
    
                if (tb != null)
                {
    
                    if ((bool)e.NewValue)
                    {
                        tb.PreviewTextInput += tb_PreviewTextInput;
                    }
                    else
                    {
                        tb.PreviewTextInput -= tb_PreviewTextInput;
                    }
                }
            }
    
            private static void tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
            {
                if (new string[] { @"\", "/", "?", "\"", "<", ">", "|", ":" }.Contains(e.Text))
                {
                    e.Handled = true;
                }
            }
        }
