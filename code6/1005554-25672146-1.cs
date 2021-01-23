    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace WpfApplication1
    {
        public partial class SplitterControl : UserControl
        {
            public string MyValue
            {
                get { return (string)GetValue(MyValueProperty); }
                set { SetValue(MyValueProperty, value); }
            }
            public static readonly DependencyProperty MyValueProperty = DependencyProperty.Register("MyValue", typeof(string), typeof(SplitterControl));        
            public SplitterControl()
            {
                InitializeComponent();
            }
            private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
            {
                root.GetBindingExpression(DataContextProperty).UpdateSource();
            }
        }
    }
