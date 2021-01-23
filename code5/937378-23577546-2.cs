    public class TextChangedUpdateSourceBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
    
            AssociatedObject.TextChanged += OnTextChanged;
        }
    
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var bindingExpression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
    
            if (bindingExpression != null)
            {
                bindingExpression.UpdateSource();
            }
        }
    }
