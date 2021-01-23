    public class StateMachine
    {
        private readonly List<Tuple<Predicate<MyBusinessObject>, Func<MyBusinessObject, StateMachine, Window>>> _matchList;
        public StateMachine()
        {
            _matchList = new List<Tuple<Predicate<MyBusinessObject>, Func<MyBusinessObject, StateMachine, Window>>>();
        }
        public void RegisterState(Predicate<MyBusinessObject> predicate, Func<MyBusinessObject, StateMachine, Window> windowFactory)
        {
            _matchList.Add(Tuple.Create(predicate, windowFactory));
        }
        public Window Next(MyBusinessObject currentState)
        {
            var entry = _matchList.Where(m => m.Item1(currentState)).FirstOrDefault();
            if (entry != null)
                return entry.Item2(currentState, this);
            return null;
        }
    }
