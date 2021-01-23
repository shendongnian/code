    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public partial class MainView : Window
        {
            public MainView()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
        }
        // put classes shown below here
    }
