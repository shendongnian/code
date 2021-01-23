    public IReadOnlyList<EnumOptions> Options { get; }
    private EnumOptions _selectedOption;
    public EnumOptions SelectedOption
    {
        get { return _selectedOption; }
        set
        {
            _selectedOption = value;
            OnPropertyChanged(() => SelectedOption);
        }
    }
    // Initialization in constructor
    Options = EnumExtensions.GetValues<EnumOptions>().ToArray();
    // If you want to set a default.
    SelectedOption = Options[0];
