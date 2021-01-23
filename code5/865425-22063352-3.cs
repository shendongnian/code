    using System;
    
    namespace SliderExample
    {
        public partial class MainWindow
        {
            TimeSpan _measureGap = TimeSpan.FromSeconds(3);
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            public double MeasureGap
            {
                get { return _measureGap.TotalSeconds; }
                set { _measureGap = TimeSpan.FromSeconds(value); }
            }
        }
    }
