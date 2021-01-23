    public class UniformGrid : Grid
    {
        public double? UniformHeight { get; set; }
        public UniformGrid()
        {
            Loaded += UniformGrid_Loaded;
        }
        void UniformGrid_Loaded(object sender, RoutedEventArgs e)
        {
            int i=0;
            foreach (FrameworkElement child in Children)
            {
                var rowHeight = UniformHeight.HasValue ? new GridLength(UniformHeight.Value) : GridLength.Auto;
                RowDefinitions.Add(new RowDefinition { Height = rowHeight });
                Grid.SetRow(child, i++);
            }
        }
    }
