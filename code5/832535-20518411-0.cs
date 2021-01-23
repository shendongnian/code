    public ModelView(Model model) : this()
    {
        var closure = new AnonymousClass { _this = this, model = model };
        Loaded += closure.Loaded;
    }
    private class AnonymousClass
    {
        public ModelView _this;
        public Model model;
        public void Loaded(object sender, RoutedEventArgs e)
        {
            _this.DataContext = model;
        }
    }
