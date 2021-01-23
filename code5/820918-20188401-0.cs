    public int Variable
        {
            get { return (int)GetValue(VariableProperty); }
            set { SetValue(VariableProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Variable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VariableProperty =
            DependencyProperty.Register("Variable", typeof(int), typeof(ownerclass), new PropertyMetadata(0));
