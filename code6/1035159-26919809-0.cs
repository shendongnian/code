        namespace Card_System.Controls
    {
    	/// <summary>
    	/// Interaction logic for StatProgressBar.xaml
    	/// </summary>
    	public partial class StatProgressBar : UserControl
    	{
            private double _trackWidth;
            private bool _isAnimate;
            private bool _isRefresh;
    
    		public StatProgressBar()
    		{
    			InitializeComponent();
    
                var descriptor = DependencyPropertyDescriptor.FromProperty(ActualWidthProperty, typeof(Border));
                if (descriptor != null)
                {
                    descriptor.AddValueChanged(TrackBorder, ActualWidth_ValueChanged);
                }
    		}
    
            
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private double _barValueSet;
            public double BarValueSet
            {
                get { return _barValueSet; }
                set 
                {
                    _barValueSet = value;
                    OnPropertyChanged("BarValueSet");
                    _isAnimate = true;
                    AnimateWidth();
                }
            }
    
            public double BarValueDesired
            {
                get { return (double)GetValue(BarValueProperty); }
                set { SetValue(BarValueProperty, value); }
            }
    
            public static readonly DependencyProperty BarValueProperty =
              DependencyProperty.Register("BarValueDesired", typeof(double), typeof(StatProgressBar), new UIPropertyMetadata(0.0d, new PropertyChangedCallback(BarValueDesired_PropertyChanged)));
    
            public double BarMaximum
            {
                get { return (double)GetValue(BarMaximumProperty); }
                set { SetValue(BarMaximumProperty, value); }
            }
    
            public static readonly DependencyProperty BarMaximumProperty =
              DependencyProperty.Register("BarMaximum", typeof(double), typeof(StatProgressBar), new UIPropertyMetadata(0.0d));
    
    
            public static void BarValueDesired_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                //Set BarValue to the value of BarValueDesired BEFORE it was just changed.
                ((StatProgressBar)d).BarValueSet = (double)e.OldValue;
            }
    
            public Brush BarColor
            {
                get { return (Brush)GetValue(BarColorProperty); }
                set { SetValue(BarColorProperty, value); }
            }
    
            public static readonly DependencyProperty BarColorProperty =
              DependencyProperty.Register("BarColor", typeof(Brush), typeof(StatProgressBar), new UIPropertyMetadata(Brushes.White, new PropertyChangedCallback(BarColor_PropertyChanged)));
    
            public static void BarColor_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((StatProgressBar)d).BarFill.Background = (Brush)e.NewValue;
    
            }
    
            private void ActualWidth_ValueChanged(object a_sender, EventArgs a_e)
            {
                _trackWidth = TrackBorder.ActualWidth;
                _isRefresh = true;
                AnimateWidth();
            }
    
            public void AnimateWidth()
            {
                if (_isAnimate && _isRefresh)
                {
                    double StartPoint = new double();
                    double EndPoint = new double();
                    double PercentEnd = new double();
                    double PercentStart = new double();
    
                    PercentStart = BarValueSet / BarMaximum;
                    StartPoint = _trackWidth * PercentStart;
                    PercentEnd = BarValueDesired / BarMaximum;
                    EndPoint = _trackWidth * PercentEnd;
    
                    DoubleAnimation animation = new DoubleAnimation(StartPoint, EndPoint, TimeSpan.FromSeconds(3));
                    this.BarFill.BeginAnimation(Border.WidthProperty, animation);
                }
                else return;
            }
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
