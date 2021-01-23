    [TestClass]
    public abstract class Base
    {
        private List<Action> SetUpActions = new List<Action>();
        private List<Action> TearDownActions = new List<Action>();
        public void SetUp()
        {
            foreach( Action a in SetUpActions )
                a.Invoke();
        }
        public void TearDown()
        {
            foreach( Action a in TearDownActions.Reverse<Action>() )
                a.Invoke();
        }
        protected void AddSetUpAction(Action a) { SetUpActions.Add(a); }
        protected void AddTearDownAction(Action a) { TearDownActions.Add(a); }
    }
