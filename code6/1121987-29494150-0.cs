    public void Start()
    {
       mousePosV2 = Mouse.GetState().Position.ToVector2();
    }
      
    public void Update(float dt)
    {
       Vector2 stickMovement = padOne.ThumbSticks.Right;
       stickMovement.Normalize();
       mousePosV2 += stickMovement*dt*desiredMouseSpeed; 
       /// clamp here values of mousePosV2 according to Screen Size
       /// ...
       Point roundedPos = new Point(Math.Round(mousePosV2.X), Math.Round(mousePosV2.Y));
       Mouse.SetPosition(roundedPos.X, roundedPos.Y);
    }
