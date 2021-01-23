    public class ScrollingToBottomBehavior
    {
        #region Private Section
        private static ListBox listBox = null;
        private static ICommand command = null;
        
        #endregion
        #region IsEnabledProperty
        public static readonly DependencyProperty IsEnabledProperty;
        public static void SetIsEnabled(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(IsEnabledProperty, value);
        }
        public static bool GetIsEnabled(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsEnabledProperty);
        }
        #endregion
        #region CommandProperty
        public static readonly DependencyProperty CommandProperty;
        public static void SetCommand(DependencyObject DepObject, ICommand value)
        {
            DepObject.SetValue(CommandProperty, value);
        }
        public static ICommand GetCommand(DependencyObject DepObject)
        {
            return (ICommand)DepObject.GetValue(CommandProperty);
        }
        static ScrollingToBottomBehavior()
        {
            IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled",
                                                                typeof(bool),
                                                                typeof(ScrollingToBottomBehavior),
                                                                new UIPropertyMetadata(false, IsFrontTurn));
            CommandProperty = DependencyProperty.RegisterAttached("Command",
                                                                typeof(ICommand),
                                                                typeof(ScrollingToBottomBehavior));
        }
        #endregion
        private static void IsFrontTurn(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            listBox = sender as ListBox;
            if (listBox == null)
            {
                return;
            }
            if (e.NewValue is bool && ((bool)e.NewValue) == true)
            {
                listBox.Loaded += new RoutedEventHandler(listBoxLoaded);
            }
        }
        private static void listBoxLoaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GetFirstChildOfType<ScrollViewer>(listBox);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged += new ScrollChangedEventHandler(scrollViewerScrollChanged);
            }
        }
        #region GetFirstChildOfType
        private static T GetFirstChildOfType<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null)
            {
                return null;
            }
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);
                var result = (child as T) ?? GetFirstChildOfType<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        #endregion
        private static void scrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
                {
                    command = GetCommand(listBox);
                    command.Execute(listBox);
                }
            }
        }
    }
