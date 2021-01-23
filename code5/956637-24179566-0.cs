      private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            ((ProgressBar)((Grid)img.Parent).Children[0]).IsIndeterminate = false;
        }
