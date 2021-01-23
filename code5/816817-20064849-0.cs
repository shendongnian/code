    // declare this as a variable in your game class
    public float PaddleSpeedUpCoolDownTime = 0.0f;
    if (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0)
    {
        PaddleSpeedUpCoolDownTime = 5.0f; // 5 seconds
        speedup1 = 5;
    }
    // in your main game loop in an appropriate place
    if (PaddleSpeedUpCoolDownTime > 0.0f)
    {
        speedup1 = speedup1 * 0.9f * frameTime; // to slow down gradually
        PaddleSpeedUpCoolDownTime = PaddleSpeedUpCoolDownTime - frameTime;
    }
