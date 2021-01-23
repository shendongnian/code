    public IList<BarButtonItem> Tasks
        {
            get { return (IList<BarButtonItem >)GetValue(TasksProperty);                }
            set { SetValue(TasksProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Colors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(IList<BarButtonItem>), typeof(CollectionView), new PropertyMetadata(new List<BarButtonItem>()));
