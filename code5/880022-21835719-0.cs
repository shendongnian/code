    public async void SomeMethod()
    {
        this.button.BackColor = Color.Green;
        await Task.Delay(2000); 
        this.button.BackColor = Color.White;
    }
