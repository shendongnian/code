     public class KeysChangedBehavior : Behavior<ComboBox>
        {
            protected override void OnAttached()
            {
                this.AssociatedObject.AddHandler(ComboBox.KeyDownEvent,
              new RoutedEventHandler(this.OnKeysChanged));
    
                this.AssociatedObject.AddHandler(ComboBox.KeyUpEvent,
        new RoutedEventHandler(this.OnKeysChanged));
            }
    
            protected void OnKeysChanged(object sender, RoutedEventArgs e)
            {
                BindingExpression _binding = ((ComboBox)sender).GetBindingExpression(ComboBox.SelectedItemProperty);
                if (_binding != null)
                    _binding.UpdateSource();
            }
        }
