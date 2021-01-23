     public void ShowNext()
    {
        if(Neurotec.Samples.Fingers.AddFingerprintsPage.Stopped) 
        {
             ShowPage(_currentPage + 1, false);
        }
    }
