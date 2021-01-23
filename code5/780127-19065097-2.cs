    public class ProportionalSizeHelper : FrameworkElement, INotifyPropertyChanged
    {
        private double _proportionalWidth = 0;
        private double _proportionalHeight = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public FrameworkElement Element
        {
            get { return (FrameworkElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }
        public double ProportionalHeight
        {
            get{ return _proportionalHeight; }
        }
        public double ProportionalWidth
        {
            get { return _proportionalWidth; }
        }
        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(FrameworkElement), typeof(ProportionalSizeHelper), 
                                        new PropertyMetadata(null,OnElementPropertyChanged));
        private static void OnElementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ProportionalSizeHelper)d).OnElementChanged(e);
        }
        private void OnElementChanged(DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement oldElement = (FrameworkElement)e.OldValue;
            FrameworkElement newElement = (FrameworkElement)e.NewValue;
            if (newElement != null)
            {   
                newElement.SizeChanged += new SizeChangedEventHandler(Element_SizeChanged);
            }
            else
            {
                _proportionalHeight = 0;
                _proportionalWidth = 0;
            }
            if (oldElement != null)
            {
                oldElement.SizeChanged -= new SizeChangedEventHandler(Element_SizeChanged);
            }
            NotifyPropChange();
        }
        private void Element_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // This can be whatever calculation you need
            double factor = Math.Min(Element.ActualWidth/1024, Element.ActualHeight/768);
            _proportionalHeight = 100*factor;
            _proportionalWidth = 300*factor;
            NotifyPropChange();
        }
        private void NotifyPropChange()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ProportionalWidth".NonNls()));
                PropertyChanged(this, new PropertyChangedEventArgs("ProportionalHeight".NonNls()));
            }
        }
    }
