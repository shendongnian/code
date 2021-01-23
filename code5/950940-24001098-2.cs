    public abstract class DataGridBehavior
    {
        private static readonly ConcurrentDictionary<Type, DataGridBehavior> Behaviors = new ConcurrentDictionary<Type, DataGridBehavior>();
        public static readonly DependencyProperty IsEnabledProperty;
        public static readonly DependencyProperty InnerTypeProperty;
        static DataGridBehavior()
        {
            IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled",
                typeof(bool), typeof(DataGridBehavior),
                new FrameworkPropertyMetadata(false, OnBehaviorEnabled));
            InnerTypeProperty = DependencyProperty.RegisterAttached("InnerType",
                typeof(Type), typeof(DataGridBehavior));
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetInnerType(DependencyObject obj, Type value)
        {
            obj.SetValue(InnerTypeProperty, value);
        }
        public static Type GetInnerType(DependencyObject obj)
        {
            return (Type)obj.GetValue(InnerTypeProperty);
        }
        private static void OnBehaviorEnabled(DependencyObject dependencyObject,
              DependencyPropertyChangedEventArgs args)
        {
            var innerType = GetInnerType(dependencyObject);
            if (innerType == null)
                throw new Exception("Missing inner type");
            var behavior = Behaviors.GetOrAdd(innerType, GetBehavior);
            behavior.OnEnabled(dependencyObject);
        }
        private static DataGridBehavior GetBehavior(Type innerType)
        {
            var behaviorType = typeof(DataGridBehavior<>).MakeGenericType(innerType);
            var behavior = (DataGridBehavior)Activator.CreateInstance(behaviorType);
            return behavior;
        }
        protected abstract void OnEnabled(DependencyObject dependencyObject);
    }
    public class DataGridBehavior<T> : DataGridBehavior
        where T : SqliteBoundRow
    {
        protected override void OnEnabled(DependencyObject dependencyObject)
        {
            //dg.InitializingNewItem += DataGrid_InitializingNewItem;
        }
        private static void DataGrid_InitializingNewItem(object sender,
            InitializingNewItemEventArgs e)
        {
            //var table = (sender as DataGrid).ItemsSource as Table<T>;
            //(e.NewItem as T).NewRow(table);
        }
    }
    public class SqliteBoundRow
    {
    }
