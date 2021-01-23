        private void AddMarkerToMap( String symbol, GeoCoordinate location )
            {
            if ( _markerLayer != null )
                {
                Map1.Layers.Remove( _markerLayer );
                _markerLayer = null;
                }
            _markerLayer = new MapLayer();
            var mapCenterMarker = new MapOverlay();
            var grid = new Grid();
            var circhegraphic = new Ellipse();
            circhegraphic.Fill = new SolidColorBrush( Color.FromArgb( 0x44, 0x00, 0xFF, 0x00 ) );
            circhegraphic.Stroke = new SolidColorBrush( Color.FromArgb( 0xFF, 0x00, 0x00, 0xFF ) );
            circhegraphic.StrokeThickness = 4;
            circhegraphic.Opacity = 0.7;
            circhegraphic.Height = 40;
            circhegraphic.Width = 40;
            grid.Children.Add( circhegraphic );
            var textBlock = new TextBlock
                {
                    Text = symbol,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontWeight = FontWeights.ExtraBold,
                    FontSize = 14,
                    Foreground = new SolidColorBrush( Color.FromArgb( 0xFF, 0xFF, 0x00, 0x00 ) )
                };
            grid.Children.Add( textBlock );
            mapCenterMarker.GeoCoordinate = location;
            mapCenterMarker.Content = grid;
            mapCenterMarker.PositionOrigin = new Point( 0.5, 0.5 );
            _markerLayer.Add( mapCenterMarker );
            Map1.Layers.Add( _markerLayer );
            }
