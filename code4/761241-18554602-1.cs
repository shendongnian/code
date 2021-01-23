    if (touchCollection.Count > 0)
    {
       TouchLocation tl = touchCollecion.Last();
       
       if (tl.State == TouchLocationState.Released && previousState == TouchLocationState.Pressed)
          {
             if (ButtonRecPlay.Contains((int)tl.Position.X, (int)tl.Position.Y))
                IsPlayClicked = true;
          }
    }
