    for (int i = 0; i < protectMaxPlayers; i++)
    {
        // Update the protect time.
        protect.setProtectTime(i, protect.getProtectTime(i) - 1);
    
        // Set the progressbar.
        ProtectProgressBar pb = pnlProtect.Controls.OfType<ProtectProgressBar>().ToList().Find(k => k.ID == i.ToString());
    
        // check if it was found
        if (pb != null)
        {
            // your code
        }
    }
