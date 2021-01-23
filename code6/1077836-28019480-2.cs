    private async void button1_Click(object sender, EventArgs e)
    {
        var dice = new Dice();
        dice.OnRolled += Dice_OnRolled;
        await Task.Run(() => dice.Roll(20));
    }
    void Dice_OnRolled(object sender, DiceEventArgs args)
    {
        this.Invoke(new Action(() => { button1.Text = args.RollNumber.ToString(); }));
    }
