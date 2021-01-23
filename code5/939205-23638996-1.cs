    private void RowIndexX(object sender, DataGridRowEventArgs e)
    {
        e.Row.Header = (e.Row.GetIndex() + 1).ToString();
    }
    private void RowIndexY(object sender, DataGridRowEventArgs e)
    {
        e.Row.Header = " ";
    }
    void ControlBindings()
    {
        var resultSections = NProjectProperties.Instance.ResultSections;
        var cable = DataContext as NCable;
        Binding binding;
        if (EqualToResults.IsChecked == true)
        {
            CoordinatesX.ItemsSource = resultSections;
            XColumn.IsReadOnly = true;
            XColumn.Foreground = Brushes.DarkGray;
            binding = new Binding();
        }
        else
        {
            CoordinatesX.ItemsSource = cable.Points;
            XColumn.IsReadOnly = false;
            XColumn.Foreground = Brushes.Black;
            binding = new Binding("X");
        }
        binding.ValidatesOnDataErrors = true;
        binding.NotifyOnValidationError = true;
        XColumn.Binding = binding;
    }
    private void EqualToResultsChanged(object sender, RoutedEventArgs e)
    {
        ControlBindings();
    }
    private void ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        var scroll1 = NU.GetDescendantByType(CoordinatesX, typeof(ScrollViewer)) as ScrollViewer;
        var scroll2 = NU.GetDescendantByType(CoordinatesY, typeof(ScrollViewer)) as ScrollViewer;
        scroll1.ScrollToVerticalOffset(scroll2.VerticalOffset);
    }
    public static class NU
    {
        public static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
    }
