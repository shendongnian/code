    protected override void OnInitialize()
    {    
        this.CharacterMetadataViewModel.Initialize(this.Character);
        this.CharacterCharacteristicsViewModel.Initialize(this.Character);    
    
        this.eventAggregator.PublishOnUIThread(new CharacterMessage
        {
            Data = this.Character
        });
    
    
        base.OnInitialize();
    }
