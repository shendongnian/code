        public static bool GetCanCloseFlyout(Button button) => (bool)button.GetValue(CanCloseFlyoutProperty);
        public static void SetCanCloseFlyout(Button button, bool value) => button.SetValue(CanCloseFlyoutProperty, value);
        public static readonly DependencyProperty CanCloseFlyoutProperty =
            DependencyProperty.RegisterAttached(CanCloseFlyoutPropertyName,
                                                typeof(bool),
                                                typeof(FlyoutAttach),
                                                new PropertyMetadata(false,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    if (s is Button button && e.NewValue is bool canCloseFlyout)
                                                    {
                                                        button.Click -= buttonClick;
                                                        if (canCloseFlyout) button.Click += buttonClick;
                                                    }
                                                    void buttonClick(object sender, RoutedEventArgs routedEventArgs)
                                                    {
                                                        var flyoutPresenter = button.GetParent<FlyoutPresenter>();
                                                        if (flyoutPresenter.Parent is Popup popup)
                                                            popup.IsOpen = false;
                                                    }
                                                })));
