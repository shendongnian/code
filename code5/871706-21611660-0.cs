    public enum ItemDisplayType {
        None,
        Detail,
        Any,
    }
    
    public class CustomClass : UserControl {
        public CustomClass () {
            // No crash when DisplayType is set
            // DisplayType = ItemDisplayType.Any;
            this.InitializeComponent();
        }
    
        public static readonly DependencyProperty DisplayTypeProperty = DependencyProperty.Register("DisplayType", typeof(ItemDisplayType), typeof(CustomClass), null);
        public ItemDisplayType DisplayType{
            get { return (ItemDisplayType)GetValue(DisplayTypeProperty); }
            set {
                SetValue(DisplayTypeProperty, value);
            }
        }
    }
