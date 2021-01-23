    private volatile bool canContinue = true;
    
    public void TimerFunc(){
        ...
        while (true && canContinue)
        {
            ...
            sound.PlayLooping();
            // Displays the MessageBox and waits for user input
            MessageBox.Show(message, caption, buttons);
            // End the sound loop
            sound.Stop();
            ...
        }
    }
    public void StopPolitely()
    {
        canContinue = false;
    }
