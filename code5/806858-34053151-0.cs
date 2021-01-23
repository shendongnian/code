        void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Visible")
            {
                if((sender as Viewport2D).Plotter==plotter)
                plotter2.Viewport.Visible = new DataRect(plotter.Viewport.Visible.XMin, plotter2.Viewport.Visible.YMin, plotter.Viewport.Visible.Width, plotter2.Viewport.Visible.Height);
                else if ((sender as Viewport2D).Plotter == plotter2)
                    plotter.Viewport.Visible = new DataRect(plotter2.Viewport.Visible.XMin, plotter.Viewport.Visible.YMin, plotter2.Viewport.Visible.Width, plotter.Viewport.Visible.Height);
            }
        }
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            // Add handler
            plotter.Viewport.PropertyChanged += new EventHandler<ExtendedPropertyChangedEventArgs>(Viewport_PropertyChanged);
            plotter2.Viewport.PropertyChanged += new EventHandler<ExtendedPropertyChangedEventArgs>(Viewport_PropertyChanged);
