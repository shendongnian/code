    public class GameClassWhereUpdateIsDone
    {
        private enum Directions { None, Up, Down, Left, Right };
    
        private int counter = 0;
        private Directions currentDirection; // Current movement-direction
        private Directions lastInput; // Last direction from input
    
        public void Update(...)
        {
           var keyboardState = Keyboard.GetState();
           if(keyboardState.IsKeyPressed(Keys.Right))
           {
               counter = 0;
               direction = Directions.Right;
           }
           if(currentDirection != lastInput && counter < 5) // Allow turning 5 updates ahead.
           {
               // Player want to turn
               if(AllowedToTurn(lastInput)
               {
                    currentDirection = lastInput;
               }
           }
           MoveDirection(currentDirection);
           counter++;
        }
      
        private bool AllowedToTurn(Directions direction)
        {
           if(direction == Directions.Right)
           {
               return RightCheck();
           }
        }
    }
