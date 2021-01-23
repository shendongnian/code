    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.
        Register("ViewModel", typeof(BaseViewModel), typeof(AnimationWindow));
    public BaseViewModel ViewModel
    {
        get { return (BaseViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }
