    public void SetPlayerAnimation(int location, int x1, int y1, TimeSpan duration1, string sprite1, int x2, int y2, TimeSpan duration2, string sprite2, int x3, int y3, TimeSpan duration3, string sprite3, string endsprite)
    {
        //Get the sprite object to be animated
        TranslateTarget = "Sprite" + location.ToString();
        OnPropertyChanged("TranslateTarget");
        Task.Factory.StartNew(
            async () => {
                RunAnimation(location, x1, y1, duration1, sprite1);
                await Task.Delay(duration1);
                RunAnimation(location, x2, y2, duration2, sprite2);
                await Task.Delay(duration2);
                RunAnimation(location, x3, y3, duration3, sprite3);
                await Task.Delay(duration2);
                SetPlayerSprite(location, endsprite);
            }, // this will use current synchronization context
            CancellationToken.None, 
            TaskCreationOptions.None, 
            TaskScheduler.FromCurrentSynchronizationContext());
    }
