Atatched Behavior
    public class SelectDateBehavior
    {
        #region IsEnabled Dependency Property
        public static readonly DependencyProperty IsEnabledProperty;
        public static void SetIsEnabled(DependencyObject DepObject, bool value)
        {
            DepObject.SetValue(IsEnabledProperty, value);
        }
        public static bool GetIsEnabled(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsEnabledProperty);
        }
        static SelectDateBehavior()
        {
            IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled",
                                                                typeof(bool),
                                                                typeof(SelectDateBehavior),
                                                                new UIPropertyMetadata(false, IsEnabledChanged));
        }
        #endregion
        #region IsEnabledChanged Handler
        private static void IsEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                if (e.NewValue is bool && ((bool)e.NewValue) == true)
                {
                    panel.Loaded += new RoutedEventHandler(panelLoaded);
                }
                else
                {
                    panel.Loaded -= new RoutedEventHandler(panelLoaded);
                }
            }
        }
        #endregion
        #region Panel Loaded Handler
        private static void panelLoaded(object sender, RoutedEventArgs e) 
        {
            Panel panel = sender as Panel;
            Border border = panel.FindName("targetBorder") as Border;
            ContentControl contentHost = border.FindName("ContentHost") as ContentControl;
            Popup popup = panel.FindName("PopCal") as Popup;
            if (popup != null)
            {
                Calendar calendar = popup.FindName("ActualCalendar") as Calendar;                
                calendar.SelectedDatesChanged += new EventHandler<SelectionChangedEventArgs>(calendarSelectedDatesChanged);
            }
            
            if (contentHost != null)
            {
                contentHost.MouseDoubleClick += new MouseButtonEventHandler(contentHostMouseDoubleClick);
            }          
        }
        #endregion
        #region ContentHost MouseDoubleClick Handler
        private static void contentHostMouseDoubleClick(object sender, MouseButtonEventArgs e) 
        {
            ContentControl contentHost = sender as ContentControl;
            Border border = contentHost.Parent as Border;
            Panel panel = border.Parent as Panel;
            Popup popup = panel.FindName("PopCal") as Popup;
            if (popup != null) 
            {
                popup.IsOpen = true;
            }
        }
        #endregion
        #region Calendar SelectedDatesChanged Handler
        private static void calendarSelectedDatesChanged(object sender, SelectionChangedEventArgs e) 
        {
            Calendar calendar = sender as Calendar;
            Popup popup = calendar.Parent as Popup;
            Panel panel = popup.Parent as Panel;
            Border border = panel.FindName("targetBorder") as Border;
            ContentControl contentHost = border.FindName("ContentHost") as ContentControl;
            if (popup != null) 
            {
                contentHost.Content = calendar.SelectedDate;
                popup.IsOpen = false;
            }
        }
        
        #endregion
    }
Output
