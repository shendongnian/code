    private void ClearControls(DependencyObject root)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
        {
            var control = VisualTreeHelper.GetChild(root, i);
            if (control is TextBox)
            {
                (control as TextBox).Text = String.Empty;
            }
            else if (control is ComboBox)
            {
                (control as ComboBox).Text = String.Empty;
            }
            else if (VisualTreeHelper.GetChildrenCount(control) > 0)
            {
                ClearControls(control);
            }
        }
    }
