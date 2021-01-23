    public GameViewModel BaseViewModel
    {
        get { return (GameViewModel)GetValue(baseViewModelProperty); }
        set { SetValue(baseViewModelProperty, value); }
    }
    public static readonly DependencyProperty baseViewModelProperty =
        DependencyProperty.Register("BaseViewModel", typeof(GameViewModel), typeof(ScoreDisplay), new PropertyMetadata(null, RegisterForScoreChange));
