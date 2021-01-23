        public enum MyState
        {
            NoState,
            IsStateA,
            IsStateB,
        }
        public MyState State { get; set; }
        public bool IsStateA { get { return State == MyState.IsStateA; } }
        public bool IsStateB { get { return State == MyState.IsStateB; } }
