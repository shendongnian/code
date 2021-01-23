        public SlideControl()
        {
            DefaultStyleKey = typeof(SlideControl);
            Loaded += SlideControl_Loaded;
        }
        public SlideContentPanel TypedPanel
        {
            get { return (SlideContentPanel)GetValue(TypedPanelProperty); }
            set { SetValue(TypedPanelProperty, value); }
        }
        public static readonly DependencyProperty SlidePanelProperty =
            DependencyProperty.Register("TypedPanel", typeof(SlideContentPanel), typeof(AnItemsControl), new PropertyMetadata(null));
