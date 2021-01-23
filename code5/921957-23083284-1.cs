    private void ScatterView_ContainerDeactivated(object sender, RoutedEventArgs e)
    {
        ScatterViewItem sourceSVI =  (ScatterViewItem)e.OriginalSource;
            
            
        Rect btn1Bounds = VisualTreeHelper.GetDescendantBounds(btnButton1);
        GeneralTransform transform1 = containerScatterView.TransformToVisual(btnButton1);
        if (btn1Bounds.Contains(transform1.Transform(sourceSVI.ActualCenter)))
        {
            Console.WriteLine("Dropped on Button 1");
        }
        Rect btn2Bounds = VisualTreeHelper.GetDescendantBounds(btnButton2);
        GeneralTransform transform2 = containerScatterView.TransformToVisual(btnButton2);
        if (btn2Bounds.Contains(transform2.Transform(sourceSVI.ActualCenter)))
        {
            Console.WriteLine("Dropped on Button 2");
        }
    }
