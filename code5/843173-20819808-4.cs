    while (TouchPanel.IsGestureAvailable)
    {
       GestureSample gs = TouchPanel.ReadGesture();
       switch (gs.GestureType)
       {
         case GestureType.Tap:
           if (button.Contains((int) gs.Position.X, (int) gs.Position.Y))
              isTimerOn = true;
         break;
       }
    }
