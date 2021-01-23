        public Task<Grid> AddModalToPanel(Panel panel)
        {
            TaskCompletionSource<Grid> tasksource = new TaskCompletionSource<Grid>();
            var gray = new SolidColorBrush(Color.FromArgb(110, 0, 0, 0));
            Grid grd = new Grid() { Background = gray };
            grd.SetValue(Grid.RowSpanProperty, 10);
            grd.SetValue(Grid.ColumnSpanProperty, 10);
            grd.Opacity = 0.01;
            grd.Loaded += async (s, e) =>
            {
                tasksource.SetResult(grd);
                //animations...
            };
            panel.Children.Add(grd);
            return tasksource.Task;
        }
