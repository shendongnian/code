        public void SetData(ObservableCollection<NameValuePair> data)
        {
            _dataPoints = data;
            _dataPoints.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(_dataPoints_CollectionChanged);
            GraphGrid.Columns = _dataPoints.Count;
            RebuildGraph();
            InvalidateVisual();
        }
        private void RebuildGraph()
        {
            GraphGrid.Children.Clear();
            GraphGrid.Height = GetLargestValue();
            GraphGrid.Width = _dataPoints.Count * 3;
            foreach (var item in _dataPoints)
            {
                AddGraphBar(item.Value);
            }
        }
        private void AddGraphBar(double value)
        {
            Border grid = new Border();
            grid.BorderBrush = Brushes.Black;
            grid.BorderThickness = new Thickness(1);
            grid.Background = Brushes.Green;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            grid.Height = value;
            GraphGrid.Children.Add(grid);
        }
