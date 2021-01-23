        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			var myRect = (Rectangle)this.FindName("myRect");
			double x = Canvas.GetLeft(myRect);
			double y = Canvas.GetTop(myRect);
            Canvas.SetLeft(myRect,x+10);
			Canvas.SetTop(myRect,y);
        }
