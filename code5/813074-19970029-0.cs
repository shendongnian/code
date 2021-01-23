    bool? _IsCorrect;  // The naming is Significant
    public bool? IsCorrect {
        get { return _IsCorrect; }
        set { this.RaiseAndSetIfChanged(x => x.IsCorrect, value); }
    }
