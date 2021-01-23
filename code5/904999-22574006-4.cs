    public string Prop
        {
            get { return (string)GetValue(PropProperty); }
            set { SetValue(PropProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Prop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropProperty =
            DependencyProperty.Register("Prop", typeof(string), typeof(MainWindow), new PropertyMetadata("Hello!!"));
</pre>
