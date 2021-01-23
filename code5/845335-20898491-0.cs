        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoveGrid();
        }
        private void MoveGrid()
        {
            var sb = new Storyboard();
            var animation = new DoubleAnimation()
            {
                To = 0,
                From = content1.ActualWidth,
                EnableDependentAnimation = true
            };
            Storyboard.SetTargetProperty(animation, "Width");
            Storyboard.SetTarget(animation, content1);
            sb.Children.Add(animation);
            sb.Begin();
        }
