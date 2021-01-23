    using System.Windows;
    
    namespace WpfTestBench
    {
        public partial class OpenFileControl
        {
            public static readonly DependencyProperty FilenameProperty =
                DependencyProperty.Register("Filename", typeof (string), typeof (OpenFileControl));
    
            public OpenFileControl()
            {
                InitializeComponent();
            }
    
            public string Filename
            {
                get { return (string)GetValue(FilenameProperty); }
                set { SetValue(FilenameProperty, value); }
            }
        }
    }
