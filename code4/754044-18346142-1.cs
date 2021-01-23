        public StateMachine InitializeStateMachine()
        {
            var stateMachine = new StateMachine();
            // If condition1 is true open Window2
            stateMachine.RegisterState(bo => bo.Condition1, (bo, sm) => new Window2(bo, sm));
            // If the sum is more than 12.5 and some value is not 42 open Window3
            stateMachine.RegisterState(bo => bo.SomeSum > 12.5 && bo.SomeValue != 42, (bo, sm) => new Window3(bo, sm));
            // The answer to life and everything will open Window4
            stateMachine.RegisterState(bo => bo.SomeValue == 42, (bo, sm) => new Window3(bo, sm));
            // More rules ...
            // If no other condition matches, open Window1
            stateMachine.RegisterState(bo => true, (bo, sm) => new Window1(bo, sm));
            return stateMachine;
        }
