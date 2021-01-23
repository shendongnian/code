    public void put()
    {   
        string strDisplayMe = ModemKind.MainClass.inBuffer.MkRequest();
        if (strDisplayMe != string.Empty)
        {
            char[] DisplayMeArr = strDisplayMe.ToCharArray();
            for (int i = 0; i <= DisplayMeArr.Length -1; ++i) 
            {
                this.UpdateUI(() => { this.display.Text += DisplayMeArr[i]; });
                Thread.Sleep(100);
            }
            this.UpdateUI(() => { this.display.Text += '\n'; });
        }
    }
    private void UpdateUI(Action handler)
    {
        this.Invoke(handler);
    }
