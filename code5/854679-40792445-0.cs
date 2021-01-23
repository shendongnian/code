        public int Columns
        {
            get { return (int) GetValue(ColumnsDependencyProperty); }
            set { SetValue(ColumnsDependencyProperty, value); }
        }
        public static readonly DependencyProperty ColumnsDependencyProperty =
            DependencyProperty.Register(nameof(Columns), typeof(int), typeof(DefinableGrid), new PropertyMetadata(0));
        DependencyPropertyDescriptor ColumnsPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(ColumnsDependencyProperty, typeof(DefinableGrid));
        public GridEx()
        {
            ColumnsPropertyDescriptor?.AddValueChanged(this, delegate
            {
                ColumnDefinitions.Clear();
                for (int i = 0; i < Columns; i++)
                    ColumnDefinitions.Add(new ColumnDefinition());
            });
        }
