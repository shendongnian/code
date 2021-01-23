                ImageSource imageSource = new BitmapImage(new Uri("yep.png",UriKind.Relative));
            System.Windows.Controls.Image image1 = new System.Windows.Controls.Image();
            image1.Source = imageSource;
            Grid.SetColumn(image1, 0);//image1 is added to column 0
            Grid.SetRow(image1, 0);//row 0
            Grid1.Children.Add(image1);
