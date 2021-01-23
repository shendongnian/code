    protected override void Update(GameTime gameTime)
    {
        if (Player_Attacking == false)
        {
            player.PlayerAnimation = playerAnimation;
        }
        else
        {
            player.PlayerAnimation = ShootingAnimation;
        }
        player.Update(gameTime);
    }
