    public async void Setup()
        {
            this.IsSettingUp = true;
            await SetupViewModels();
            //Other initialization stuff here if needed
            this.IsSettingUp = false;
        }
