    public class RowDefinitionObserver {
        public static readonly DependencyProperty ObserveRowProperty = DependencyProperty.RegisterAttached(
            "ObserveRow",
            typeof(bool),
            typeof(RowDefinitionObserver),
            new FrameworkPropertyMetadata(OnObserveChanged));
        public static readonly DependencyProperty ObservedRowHeightProperty = DependencyProperty.RegisterAttached(
            "ObservedRowHeight",
            typeof(double),
            typeof(RowDefinitionObserver));
        public static bool GetObserveRow(FrameworkElement frameworkElement) {
            return (bool)frameworkElement.GetValue(ObserveRowProperty);
        }
        public static void SetObserveRow(FrameworkElement frameworkElement, bool observe) {
            frameworkElement.SetValue(ObserveRowProperty, observe);
        }
        public static double GetObservedRowHeight(FrameworkElement frameworkElement) {
            return (double)frameworkElement.GetValue(ObservedRowHeightProperty);
        }
        public static void SetObservedRowHeight(FrameworkElement frameworkElement, double observedHeight) {
            frameworkElement.SetValue(ObservedRowHeightProperty, observedHeight);
        }
        private static void OnObserveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
            var frameworkElement = (FrameworkElement)dependencyObject;
            if ((bool)e.NewValue) {
                frameworkElement.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(frameworkElement);
            } else {
                frameworkElement.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }
        private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e) {
            UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        }
        
        private static void UpdateObservedSizesForFrameworkElement(FrameworkElement frameworkElement) {
            Grid g = frameworkElement as Grid;
            if (g != null) {
                if (g.RowDefinitions.Count > 1) {
                    SetObservedRowHeight(g, g.RowDefinitions[1].ActualHeight);
                }
            }
        }
    }
