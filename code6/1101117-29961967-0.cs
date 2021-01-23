     public class Item
    {
        #region Public Properties
        public string Label { get; set; }
        #endregion Public Properties
    }
    public class BoxPlotSeriesExample
    {
        #region Public Constructors
        public BoxPlotSeriesExample()
        {
        }
        #endregion Public Constructors
        #region Public Methods
        public PlotModel createBoxPlot()
        {
            const int boxes = 16;
            var plot = new PlotModel();
            var items = new Collection<Item>();
            for (int i = 1; i < boxes + 1; i++)
            {
                items.Add(new Item { Label = i.ToString() });
            }
            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                MajorStep = 1,
                MinorStep = 0.25,
                TickStyle = TickStyle.Crossing,
                AbsoluteMaximum = 5.25,
                AbsoluteMinimum = -0.25
            });
            plot.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = items,
                LabelField = "Label",
                IsTickCentered = true,
                TickStyle = TickStyle.None,
                AbsoluteMinimum = -1,
                AbsoluteMaximum = 17,
                IsZoomEnabled = false
            });
            var lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 5,
                LineStyle = LineStyle.Dash,
                StrokeThickness = 2,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);
            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 1,
                LineStyle = LineStyle.Dash,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);
            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 4,
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);
            lineAnnotation = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 2,
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1.5,
                Color = OxyColor.FromArgb(50, 0, 0, 0)
            };
            plot.Annotations.Add(lineAnnotation);
            var s1 = new BoxPlotSeries();
            s1.Fill = OxyColor.FromRgb(0x1e, 0xb4, 0xda);
            s1.StrokeThickness = 1.1;
            s1.WhiskerWidth = 1;
            var random = new Random();
            for (int i = 0; i < boxes; i++)
            {
                double x = i;
                var points = 5 + random.Next(15);
                var values = new List<double>();
                for (int j = 0; j < points; j++)
                {
                    values.Add((random.NextDouble()) * 5);
                }
                values.Sort();
                var median = getMedian(values);
                int r = values.Count % 2;
                double firstQuartil = getMedian(values.Take((values.Count + r) / 2)); // 25%-Quartil
                double thirdQuartil = getMedian(values.Skip((values.Count - r) / 2)); // 75%-Quartil
                var iqr = thirdQuartil - firstQuartil; // Quartilabstand
                var step = 1.5 * iqr;
                var upperWhisker = thirdQuartil + step;
                upperWhisker = values.Where(v => v <= upperWhisker).Max();
                var lowerWhisker = firstQuartil - step;
                lowerWhisker = values.Where(v => v >= lowerWhisker).Min();
                var outliers = values.Where(v => v > upperWhisker || v < lowerWhisker).ToList();
                s1.Items.Add(new BoxPlotItem(x, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker, outliers));
            }
            plot.Series.Add(s1);
            return plot;
        }
        #endregion Public Methods
        #region Private Methods
        private static double getMedian(IEnumerable<double> values)
        {
            var sortedInterval = new List<double>(values);
            sortedInterval.Sort();
            var count = sortedInterval.Count;
            if (count % 2 == 1)
            {
                return sortedInterval[(count - 1) / 2];
            }
            return 0.5 * sortedInterval[count / 2] + 0.5 * sortedInterval[(count / 2) - 1];
        }
        #endregion Private Methods
    }
