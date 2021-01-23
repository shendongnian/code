    private void UpdateItemCheckedStateUnderline()
    {
        var currentValue = rtb.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
        TextDecorationCollection collection = null;
        if (currentValue is TextDecorationCollection && currentValue != DependencyProperty.UnsetValue)
        {
            collection = currentValue as TextDecorationCollection;
        }
        btnUnderline.IsChecked = collection != null && collection.Count > 0;
    }
