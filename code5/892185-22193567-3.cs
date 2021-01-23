    using System.Windows;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for View1.xaml
        /// </summary>
        public partial class View1 : Window
        {
            public View1()
            {
                InitializeComponent();
            }
            public View1(MyViewModel viewModel)
                : this()
            {
                this.DataContext = viewModel;
            }
        }
    }
