    public class FlashNotificationBehavior
    {
        public static readonly DependencyProperty FlashNotificationsProperty =
            DependencyProperty.RegisterAttached(
            "FlashNotifications",
            typeof(IEnumerable),
            typeof(FlashNotificationBehavior),
            new UIPropertyMetadata(null, OnFlashNotificationsChange));
        private static void OnFlashNotificationsChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var collection = e.NewValue as INotifyCollectionChanged;
            collection.CollectionChanged += (sender, args) => 
                {
                    if (args.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (var items in args.NewItems)
                            MessageBox.Show(items.ToString());
                    }
                };            
        }
        public static IEnumerable GetFlashNotifications(DependencyObject d)
        {
            return (IEnumerable)d.GetValue(FlashNotificationsProperty);
        }
        public static void SetFlashNotifications(DependencyObject d, IEnumerable value)
        {
            d.SetValue(FlashNotificationsProperty, value);
        }
    }
