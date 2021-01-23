    [ContentProperty("Items")] //This allows the "Items" property to be implicitly used in XAML.
    public class MyControl : Control
    {
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", 
            typeof(ObservableCollection<MyItem>), 
            typeof(MyControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnItemsChangedProperty));
        //CLR-property.
        [Category("MyControl")]
        public ObservableCollection<MyItem> Items
        {
            get { return (ObservableCollection<MyItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public MyControl() : base()
        {   //Set a new collection per control, but don't destroy binding.
            SetCurrentValue(ItemsProperty, new ObservableCollection<MyItem>());
        }
        protected override void OnRender(DrawingContext dc)
        {
            //Draw stuff here.
        }
        //More methods defined later...
    }
