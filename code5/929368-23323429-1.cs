        private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(e.Text, false);
            if(e.Handled)
            {
                var be = BindingOperations.GetBindingExpression(AssociatedObject, TextBox.TextProperty);
                Validation.MarkInvalid(be, new ValidationError(new DummyValidationRule(), be.ParentBinding));
            }
        }
        private class DummyValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                return new ValidationResult(false, "ErrorMessage");
            }
        }
