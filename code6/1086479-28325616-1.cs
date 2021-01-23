    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace WPF
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
                this.MyLabel = "Hello";
            }
    
    
    
            public string MyLabel
            {
                get { return (string)GetValue(MyLabelProperty); }
                set { SetValue(MyLabelProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for MyLabel.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MyLabelProperty =
                DependencyProperty.Register("MyLabel", typeof(string), typeof(Window2), new PropertyMetadata(""));
    
            
    
        }
    }
