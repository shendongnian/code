            public LoadingAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            _visuals = new VisualCollection(this);
            _contentPresenter = new ContentPresenter();
            _visuals.Add(_contentPresenter);
            _grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            _contentPresenter.Content = _grid; // Or the single control you want to display
            // Add your controls here to grid
        }
        protected override int VisualChildrenCount
        {
            get { return _visuals.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return _visuals[index];
        }
        protected override Size MeasureOverride(Size constraint)
        {
            _contentPresenter.Measure(constraint);
            return _contentPresenter.DesiredSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            _contentPresenter.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            return _contentPresenter.RenderSize;
        }
