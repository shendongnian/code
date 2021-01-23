    public class Player
    {
        private Aircraft _aircraft;
        private float _playerSpeed = 200f;
        
        private readonly IDictionary<Keyboard.Key, ActionMove> _keyBinding =
            new Dictionary<Keyboard.Key, ActionMove>
            {
                { Keyboard.Key.Left,ActionMove.MoveLeft },
                { Keyboard.Key.Right,ActionMove.MoveRight },
                { Keyboard.Key.Up,ActionMove.MoveUp },
                { Keyboard.Key.Down,ActionMove.MoveDown }
            };
            
        private readonly IDictionary<ActionMove,ICommand> _actionBinding =
            new Dictionary<ActionMove,Action>
            {
                { ActionMove.MoveRight, () => MoveAircraft(_playerSpeed, 0f, _aircraft) },
                { ActionMove.MoveUp, () => MoveAircraft(0f, -_playerSpeed, _aircraft) },
                ...
            };
        public MoveAircraft(float vx, float vy, Aircraft v_aircraft) 
        {
            var velocity = new Vector2f(vx, vy);
            aircraft.Accelerate(_velocity);
        }
        
        ...
    }
