    public  async void Bar()
    {
        this.button.Focus();
        this.button.BackColor = Color.Green;
        await Task.WhenAny(Task.Delay(2000), button.WhenClicked());
        // now the loop continues and the button changes its color
        this.button.BackColor = Color.White;
    }
