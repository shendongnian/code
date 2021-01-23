    public class MultiChart : Chart
    {
        public IEnumerable SeriesSource
        {
            get
            {
                return (IEnumerable)GetValue(SeriesSourceProperty);
            }
            set
            {
                SetValue(SeriesSourceProperty, value);
            }
        }
        public static readonly DependencyProperty SeriesSourceProperty = DependencyProperty.Register(
            name: "SeriesSource",
            propertyType: typeof(IEnumerable),
            ownerType: typeof(MultiChart),
            typeMetadata: new PropertyMetadata(
                defaultValue: default(IEnumerable),
                propertyChangedCallback: new PropertyChangedCallback(OnSeriesSourceChanged)
            )
        );
        private static void OnSeriesSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IEnumerable newValue = (IEnumerable)e.NewValue;
            MultiChart source = (MultiChart)d;
            source.Series.Clear();
            foreach (LineSeries item in newValue)
            {
                source.Series.Add(item);
            }
        }
    }
