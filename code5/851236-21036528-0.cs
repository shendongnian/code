    //First create the image control
    Image newImg = new Image();
    //Modify its properties (for example the source)
    newImg.Source = new BitmapImage(new Uri("http://www.whatever.com/pictures/jhondoe.jpg"));
    //Next, create the grip
    Grid newGrid = new Grid();
    newGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
    newGrid.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
    newGrid.Margin = new Thickness(0);
    //Add the Image as a Grid Child
    newGrid.Children.Add(newImg);
    
    //Finally you can do something like this:
    MySecondPivotItem.Content = newGrid
