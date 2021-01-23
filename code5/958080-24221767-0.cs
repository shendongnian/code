        private void ImgWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (dg != null)
            {
                dg.Columns[0].Width = ImgWidth.Value;
            }
        }
