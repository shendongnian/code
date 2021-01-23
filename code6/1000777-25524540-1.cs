    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1
    {
        public partial class LoadDataView : UserControl
        {
            public LoadDataViewModel Model
            {
                get { return (LoadDataViewModel)GetValue(ModelProperty); }
                set { SetValue(ModelProperty, value); }
            }
            public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(LoadDataViewModel), typeof(LoadDataView));
            public LoadDataView()
            {
                InitializeComponent();
                this.DataContext = this;
            }
        }
    }
