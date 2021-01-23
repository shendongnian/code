        MouseState lastmousestate, currentmousestate;
        lastmousestate = currentmousestate;    
        currentmousestate = Mouse.GetState();
        
        if (lastmousestate.LeftButton == ButtonState.Released && currentmousestate.LeftButton == ButtonState.Pressed)
        {
             //code here
        }
