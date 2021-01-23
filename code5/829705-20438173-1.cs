    switch (e.KeyCode)
    {
    case Keys.NumLock:
                if(numLock)
                numLock=false;
                else
                numLock=true;
                e.Handled = true;
                getNumlockState(sender, e);
                break;                
    case Keys.NumPad0:
                e.Handled = true;
                btnZero.PerformClick();
                break;
    case Keys.NumPad1:
                e.Handled = true;
                btnOne.PerformClick();
                break;
    // I have removed the case statements for most of the keys
    
    }
