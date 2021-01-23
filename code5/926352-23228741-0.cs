    protected override void OnExiting(Object sender, EventArgs args)
    {
        using (Game2 game = new Game2())
        {
            game.Run();
        }
        base.OnExiting(sender, args);
    }
