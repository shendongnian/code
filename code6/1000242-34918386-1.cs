    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(WizardViewModel), typeof(MyWizardPage));
    public WizardViewModel ViewModel
    {
      get { return (WizardViewModel)GetValue(ViewModelProperty); }
      set { SetValue(ViewModelProperty, value); }
    }// ViewModel
