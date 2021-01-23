    class InputManager
    {
       KeyBoardState state;
       // call every update
       public void Update()
       {
          state = Keyboard.GetState();
       }
       public bool IsKeyDown(Keys key)
       {
          return state.IsKeyDown(key);
          // or return key == null ? false : state.IsKeyDown(Keys.key);
          // but you would never call this method with a null key, that'd be stupid.
       }
    }
