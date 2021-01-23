    bool _jump;
    private void OnUpdate(object sender, GameTimerEventArgs e)
    {
        // ...
        if (mousestate.LeftButton==ButtonState.Pressed)
        {
             if(!_jump)
             {
                 // start jumping
                 _jump = true;
             }
             else
             {
                 // jumping in progress
                 _jumpframe++;
                 // end of jumping check
                 if(_jumpframe > 24)
                 {
                     _jumpframe = 0;
                     _jump = false;
                 }
             }
             jump();
        }
    }
