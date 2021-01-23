    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    namespace WpfApplication1
    {
        [ContentProperty("NewControls")]
        public partial class BaseControl : UserControl
        {
            public UIElementCollection NewControls
            {
                get { return (UIElementCollection)GetValue(NewControlsProperty); }
                set { SetValue(NewControlsProperty, value); }
            }
            public static readonly DependencyProperty NewControlsProperty = DependencyProperty.Register("NewControls", typeof(UIElementCollection), typeof(BaseControl));
            public BaseControl()
            {
                InitializeComponent();
                this.NewControls = new UIElementCollection(this, this);
                this.Loaded += BaseControl_Loaded;
            }
            void BaseControl_Loaded(object sender, RoutedEventArgs e)
            {
                foreach (UIElement element in NewControls.Cast<UIElement>().ToList())
                {
                    NewControls.Remove(element);
                    this.newPanel.Children.Add(element);
                }
            }
        }
    }
