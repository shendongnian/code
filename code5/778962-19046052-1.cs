     Plotter.Loaded += (s, e) => Plotter.Viewport.PropertyChanged += ViewportOnPropertyChanged;
     private void ViewportOnPropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
            {
                var minX = XAxis.AxisControl.Range.Min;
                var maxX = XAxis.AxisControl.Range.Max;
                var minY = YAxis.AxisControl.Range.Min;
                var maxY = YAxis.AxisControl.Range.Max;
            }
