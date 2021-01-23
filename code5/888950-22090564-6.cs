    public void SetText(string text, int i)
    {
        this.SafeInvoke(() =>
        {
            switch (i)
            {
                case 1:
                    this.label1.Text = text;
                    break;
                case 2:
                    this.label2.Text = text;
                    break;
            }
        });   
    }
