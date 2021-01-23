    public void Update(MouseState mouse)
    {
		MouseState lastmousestate, currentmousestate;
		lastmousestate = currentmousestate;    
		currentmousestate = Mouse.GetState();
		
        Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
        if (mouseRectangle.Intersects(rectangle))
        {
            this.isMousOver = true;
             if (lastmousestate.LeftButton == ButtonState.Released && currentmousestate.LeftButton == ButtonState.Pressed)
            {
                isPressed = true;
                this.isClicked = true;
            }
            else
            {
                this.isClicked = false;
                isPressed = false;
            }
        }
        else
        {
            this.isMousOver = false;
            this.isClicked = false;
        }
    }
