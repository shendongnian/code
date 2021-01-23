    private void listFavs_Hold(object sender, System.Windows.Input.GestureEventArgs e)
    {
        try
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            if (element is TextBlock)
            {
                String item = (String)element.DataContext;
                var booze = item.ToString();
                // rest of code
            }
        }
