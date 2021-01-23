        public static Grid Icon()
        {
            Grid mygrid = new Grid();
            string thedata = "F1 M 36.4167,19C 44.2867,19 50.6667,24.6711 50.6667,31.6667C 50.6667,32.7601 50.5108,33.8212 50.2177,34.8333L 36.4167,57L 22.6156,34.8333C 22.3225,33.8212 22.1667,32.7601 22.1667,31.6667C 22.1667,24.6711 28.5466,19 36.4167,19 Z M 36.4167,27.7083C 34.2305,27.7083 32.4583,29.4805 32.4583,31.6667C 32.4583,33.8528 34.2305,35.625 36.4167,35.625C 38.6028,35.625 40.375,33.8528 40.375,31.6667C 40.375,29.4805 38.6028,27.7083 36.4167,27.7083 Z";
            Path path = new Path();
            path.Height = 40;
            path.Width = 30;
            path.Fill = new SolidColorBrush(Colors.Red);
            path.Data = Geometry.Parse(thedata);
            mygrid.Children.Add(path);
            return mygrid;
        }
