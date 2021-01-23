    private void AddClass_Click_1(object sender, RoutedEventArgs e)
    {
        if(myCanvas == null)
        {
            myCanvas = new Canvas();
            newcanvas.Background = greenBrush;
            newcanvas.Width=500; 
            newcanvas.Height=500; 
            newcanvas.Margin=size;
            newcanvas.Name = "Class3";
        }
        GridView temp = new GridView();
        newcanvas.Children.Add(temp);
        classes.Items.Add(newcanvas);
    }
