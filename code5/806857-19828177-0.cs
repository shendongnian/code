    // Add handler
            SpeedChart.Viewport.PropertyChanged += new EventHandler<ExtendedPropertyChangedEventArgs>(Viewport_PropertyChanged);
    // Respond to changes
            void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Visible")
                {
                    StrokeChart.Viewport.Visible = new DataRect(SpeedChart.Viewport.Visible.XMin, StrokeChart.Viewport.Visible.YMin, SpeedChart.Viewport.Visible.Width, StrokeChart.Viewport.Visible.Height);
                }
            }
