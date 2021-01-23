    public class ButtonAttach : DependencyObject
    {
        private const string FlyoutButtonToClosePropertyName = "FlyoutToClose";
        public static Flyout GetFlyoutToClose(Button button) => (Flyout)button.GetValue(FlyoutToCloseProperty);
        public static void SetFlyoutToClose(Button button, Flyout value) => button.SetValue(FlyoutToCloseProperty, value);
        public static readonly DependencyProperty FlyoutToCloseProperty =
            DependencyProperty.RegisterAttached(FlyoutButtonToClosePropertyName, 
                                                typeof(Flyout), 
                                                typeof(ButtonAttach), 
                                                new PropertyMetadata(null,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    var button = s as Button;
                                                    var flyout = e.NewValue as Flyout;
                                                    button.Click -= buttonClick;
                                                    button.Click += buttonClick;
                                                    void buttonClick(object sender, RoutedEventArgs routedEventArgs) => flyout.Hide();
                                                })));
    }
