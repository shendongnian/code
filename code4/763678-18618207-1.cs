    KeyboardController keyboardController = new KeyboardController();
    public void Update()
    {
       // you should implement a method like this
       KeyboardState keyboard = keyboardController.GetKeyboardState();
       if (keyboard.IsKeyDown(Keys.F))
       {
          //change marioSprite instance         
       }
       if (keyboard.IsKeyDown(Keys.D))
       {
          //change marioSprite instance
       }
     }
