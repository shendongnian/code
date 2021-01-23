    public double Actualprogress
    {
    get { return (double)GetValue(ActualprogressProperty); }
    set { SetValue(ActualprogressProperty, value); }
    }
    public static readonly DependencyProperty ActualprogressProperty =
    DependencyProperty.Register("Actualprogress", typeof(double), typeof(ProgressBar), 
    new PropertyMetadata(0.0));
