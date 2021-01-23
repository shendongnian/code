    // For instance, I Added a MyTextBox_Unloaded event handler and tried calling:
    private void MyTextBox_Unloaded(object sender, RoutedEventArgs e)
    {
        // none of these worked
        (sender as MyTextBox).ClearValue(MyTextBox.TextProperty); // this is what DataGridTextColumn internally uses
        BindingOperations.ClearAllBindings((sender as MyTextBox));
        (sender as MyTextBox).SetValue(MyTextBox.TextProperty, null);
        (sender as MyTextBox).Text = null;
        BindingOperations.ClearBinding((sender as MyTextBox), MyTextBox.TextProperty);
    }
    // I also tried, this:
    private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
         var cp = e.EditingElement as ContentPresenter;
         var child = (VisualTreeHelper.GetChild(cp, 0) as UIElement);
         BindingOperations.ClearBinding(cp.BindingGroup.BindingExpressions[0].Target, cp.BindingGroup.BindingExpressions[0].TargetProperty);
         (child as MyTextBox).ClearValue(MyTextBox.TextProperty);
         BindingOperations.ClearAllBindings(child as MyTextBox);
         cp.BindingGroup.BindingExpressions.Clear();
    }
