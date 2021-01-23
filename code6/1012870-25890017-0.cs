    int numClicks=0;
    void OnUpgrade()
    {
        numClicks++;
        if (numClicks == 3)
        {
            GV.CpsCostAmount = GV.CpsCostAmount * 2;
            numClicks = 0;
        }
    }
