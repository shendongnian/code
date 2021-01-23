    public class FlyoutAttach : DependencyObject
    {
        private const string CloseButtonPropertyName = "CloseButton";
        private const string CanCloseFlyoutPropertyName = "CanCloseFlyout";
        private const string ClosedCommandPropertyName = "ClosedCommand";
        private const string ClosedCommandParameterPropertyName = "ClosedCommandParameter";
        public static Button GetCloseButton(Flyout flyout) => (Button)flyout.GetValue(CloseButtonProperty);
        public static void SetCloseButton(Flyout flyout, Button value) => flyout.SetValue(CloseButtonProperty, value);
        public static readonly DependencyProperty CloseButtonProperty =
            DependencyProperty.RegisterAttached(CloseButtonPropertyName,
                                                typeof(Button),
                                                typeof(FlyoutAttach),
                                                new PropertyMetadata(null,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    if (s is Flyout flyout && e.NewValue is Button button)
                                                    {
                                                        button.Click -= buttonClick;
                                                        button.Click += buttonClick;
                                                    }
                                                    void buttonClick(object sender, RoutedEventArgs routedEventArgs) => flyout.Hide();
                                                })));
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
                                                        if (flyoutPresenter?.Parent is Popup popup)
                                                            popup.IsOpen = false;
                                                    }
                                                })));
        public static ICommand GetClosedCommand(Flyout flyout) => (ICommand)flyout.GetValue(ClosedCommandProperty);
        public static void SetClosedCommand(Flyout flyout, ICommand value) => flyout.SetValue(ClosedCommandProperty, value);
        public static readonly DependencyProperty ClosedCommandProperty =
            DependencyProperty.RegisterAttached(ClosedCommandPropertyName, 
                                                typeof(ICommand), 
                                                typeof(FlyoutAttach), 
                                                new PropertyMetadata(null,
                                                new PropertyChangedCallback((s, e) =>
                                                {
                                                    if (s is Flyout flyout && e.NewValue is ICommand command)
                                                    {
                                                        flyout.Closed -= flyoutClosed;
                                                        flyout.Closed += flyoutClosed;
                                                        void flyoutClosed(object sender, object ee)
                                                        {
                                                            var commandParameter = flyout.GetValue(ClosedCommandParameterProperty);
                                                            if (command.CanExecute(commandParameter))
                                                                command.Execute(commandParameter);
                                                        }
                                                    }
                                                })));
        public static object GetClosedCommandParameter(Flyout flyout) => flyout.GetValue(ClosedCommandParameterProperty);
        public static void SetClosedCommandParameter(Flyout flyout, object value) => flyout.SetValue(ClosedCommandParameterProperty, value);
        public static readonly DependencyProperty ClosedCommandParameterProperty =
            DependencyProperty.RegisterAttached(ClosedCommandParameterPropertyName, typeof(object), typeof(FlyoutAttach), new PropertyMetadata(null));
    }
