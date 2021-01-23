        private static readonly DependencyPropertyKey IsPopupOpenPropertyKey = DependencyProperty.RegisterReadOnly(
            "IsPopupOpen",
            typeof(bool),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(false)
            );
        private static readonly DependencyProperty IsPopupOpenProperty = IsPopupOpenPropertyKey.DependencyProperty;
        public bool IsPopupOpen
        {
            get { return (bool)GetValue(IsPopupOpenProperty); }
            private set { SetValue(IsPopupOpenPropertyKey, value); }
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == UIElement.IsMouseOverProperty ||
                e.Property == UIElement.IsKeyboardFocusWithinProperty)
            {
                IsPopupOpen =
                    txtSearch.IsMouseOver ||
                    txtSearch.IsKeyboardFocusWithin;
            }
        }
