        bool firstPointCaptured = false;
        Point startPoint;
        Point endPoint;
        private void get_Scaling(object sender, MouseButtonEventArgs e)
        {
            if (Scale_btn.IsChecked == true)
            {
                if (!firstPointCaptured)
                {
                    startPoint = Mouse.GetPosition(canvas1);
                    firstPointCaptured = true;
                }
                else
                {
                    endPoint = Mouse.GetPosition(canvas1);
                    System.Windows.MessageBox.Show("Start point is" + startPoint + "and end point is" + endPoint, "test", MessageBoxButton.OK, MessageBoxImage.Information);
                    Scale_btn.IsChecked = false;
                    firstPointCaptured = false;
                }
            }
        }
