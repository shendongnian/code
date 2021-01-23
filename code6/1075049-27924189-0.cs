    Image rov = new Image();
    private void FindROVButton_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedNode != null)
        {
            if (System.Windows.MessageBox.Show("Calculate ROV location from \"" + SelectedNode.Name + "\"?", "Calculate ROV Location", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Point rovPosition = new Point();
                    rovPosition = calculateROV_position(SelectedNode.X, SelectedNode.Y, SelectedNode.Range, SelectedNode.Bearing);
                    rov.Source = new BitmapImage(new Uri("D:\\Dev\\trunk\\Software\\Nav Assist\\Data\\Hull Cleaner Tiny Image.png"));
                    canvas1.Children.Remove(rov);
                    rov.Width = 30;
                    rov.Height = 30;
                    Canvas.SetLeft(rov, (rovPosition.X - (rov.Width / 2.0)));
                    Canvas.SetTop(rov, (rovPosition.Y - (rov.Height / 2.0)));
                    canvas1.Children.Add(rov);
                }
            }
        }
