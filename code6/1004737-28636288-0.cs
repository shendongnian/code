    [ImportingConstructor]
    public CharacterViewModel(IEventAggregator eventAggregator,
    							CharacterGeneralViewModel generalViewModel,
    							CharacterMetadataViewModel metadataViewModel,
    							CharacterAppearanceViewModel appearanceViewModel,
    							CharacterFamilyViewModel familyViewModel)
    {
        this.eventAggregator = eventAggregator;
        this.CharacterGeneralViewModel generalViewModel;
        this.CharacterMetadataViewModel = metadataViewModel;
        this.CharacterCharacteristicsViewModel = apperanceViewModel;
        this.CharacterFamilyViewModel = familyViewModel;
    
        this.eventAggregator.Subscribe(this);
    }
