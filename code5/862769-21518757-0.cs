    MouseState mouseClick = Mouse.GetState();
    if (Mouse.GetState().X == buttonPosition.X && Mouse.GetState().Y == buttonPosition.Y)
        {
        if (mouseClick.LeftButton == ButtonState.Pressed)
        {
            //Your process when the button is pressed
        }
    }
