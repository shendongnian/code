        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            //Get the sourrounding ScatterViewItem via the VisualTree
            System.Windows.Media.Visual parent = (System.Windows.Media.Visual)VisualTreeHelper.GetParent((System.Windows.Media.Visual)sender);
            while (!(parent is ScatterViewItem))
            {
                parent = (System.Windows.Media.Visual)VisualTreeHelper.GetParent((System.Windows.Media.Visual)parent);
            }
            
            //the current parent is the surrounding SVI
            ScatterViewItem svi = parent as ScatterViewItem;
            
            //Bind the properties to the SVI
            Binding myBinding = new Binding("Size");
            myBinding.Source = svi.DataContext;
            svi.SetBinding(ScatterViewItem.HeightProperty, myBinding);
            svi.SetBinding(ScatterViewItem.WidthProperty, myBinding);
        }
