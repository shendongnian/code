    private void ScatterView_ContainerDeactivated(object sender, RoutedEventArgs e)
    {
        ScatterViewItem sourceSVI =  (ScatterViewItem)e.OriginalSource;
            
        //Retrieve Button1 size
        Rect btn1Bounds = VisualTreeHelper.GetDescendantBounds(btnButton1);
        //Get the transform between SV and the button1. We need it because ActualCenter is relative to SV.
        GeneralTransform transform1 = containerScatterView.TransformToVisual(btnButton1);
        if (btn1Bounds.Contains(transform1.Transform(sourceSVI.ActualCenter)))
        {
            //If ActualPoint is in bounds of the button1 then do something
            Console.WriteLine("Dropped on Button 1");
        }
        //Retrieve Button2 size
        Rect btn2Bounds = VisualTreeHelper.GetDescendantBounds(btnButton2);
        //Get the transform between SV and the button1. We need it because ActualCenter is relative to SV.
        GeneralTransform transform2 = containerScatterView.TransformToVisual(btnButton2);
        if (btn2Bounds.Contains(transform2.Transform(sourceSVI.ActualCenter)))
        {
            //If ActualPoint is in bounds of the button2 then do something else
            Console.WriteLine("Dropped on Button 2");
        }
    }
