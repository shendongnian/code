    var bars = pnlProtect.Controls.OfType<ProtectProgressBar>().ToDictionary(c => c.Id, c => c);
    for (int i = 0; i < protectMaxPlayers; i++)
    {
        // Update the protect time.
        protect.setProtectTime(i, protect.getProtectTime(i) - 1);
    
        ProtectProgressBar bar;
        if(bars.TryGetValue(i, out bar))
        {
            bar.Value = protect.getProtectTime(i);
        }
    }
