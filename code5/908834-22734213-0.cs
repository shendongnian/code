        class ModeContext
        {
        private int rotationCount;
        private string direction;
        private State state;
        public RotaryEncoder rotaryEncoderInstance;
        
        public ModeContext( RotaryEncoder re)
        {
            this.State = new RPMMode(this);
            rotaryEncoderInstance = re;
            re.RotationEventHandler += OnRotationEvent;//attach to Context's Handler
            rotationCount = 0;
        }
        public State State
        {
            get { return state; }
            set { state = value; }//debug state change
        }
        //Event Handler        
        public void OnRotationEvent(uint data1, uint data2, DateTime time)
        {
            rotationCount++;
            if (data1 == 1) 
            { 
                direction = "Clockwise";
                state.OnCWRotationEvent(this);
            }
            else
            { 
                direction = "Counter-Clockwise";
                state.OnCCWRotationEvent(this);
            }
            Debug.Print(rotationCount.ToString() + ": " + direction + " Context Mode Rotation Event Fired!");
        }
