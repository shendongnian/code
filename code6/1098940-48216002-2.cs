    public class FlyoutAttach : DependencyObject
    {
        private const string CloseButtonPropertyName = "CloseButton";
        public static Button GetCloseButton(Flyout flyout) =>(Button)flyout.GetValue(CloseButtonProperty);
        public static void SetCloseButton(Flyout flyout, Button value) => flyout.SetValue(CloseButtonProperty, value);
        public static readonly DependencyProperty CloseButtonProperty =
            DependencyProperty.RegisterAttached(CloseButtonPropertyName, 
                                                typeof(Button), 
                                                typeof(FlyoutAttach), 
                                                new PropertyMetadata(null,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    var flyout = s as Flyout;
                                                    var button = e.NewValue as Button;
                                                    button.Click -= buttonClick;
                                                    button.Click += buttonClick;
                                                    void buttonClick(object sender, RoutedEventArgs routedEventArgs) => flyout.Hide();
                                                })));
    }
