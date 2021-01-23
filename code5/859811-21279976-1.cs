    public class TypeData
    {
        public string Name { get; set; }
        public List<Data> Data { get; set; }
    }
    public class Data
    {
        public enum State
        {
            Unassigned,
            Original,
            Modified
        }
        private double _Value = 0.0d;
        public double Value
        {
            get { return _Value; }
            set
            {
                if (CurrentState == State.Unassigned)
                    CurrentState = State.Original;
                else
                    CurrentState = State.Modified;
                _Value = value;
                _ValueHistory.Add(value);
                if (_ValueHistory.Count > MaxHistoryCount)
                    ClearValueHistory();
            }
        }
        private List<double> _ValueHistory = new List<double> { 0.0d };
        private List<double> ValueHistory
        {
            get { return _ValueHistory; }
            set { _ValueHistory = value; }
        }
        private int _MaxHistoryCount = int.MaxValue;
        public int MaxHistoryCount
        {
            get { return _MaxHistoryCount; }
            set { _MaxHistoryCount = value; }
        }
        public void ClearValueHistory()
        {
            if (_ValueHistory.Count > 1)
                _ValueHistory.RemoveRange(0, _ValueHistory.Count - 1); // keep last
        }
        private State _CurrentState = State.Unassigned;
        public State CurrentState
        {
            get { return _CurrentState; }
            private set { _CurrentState = value; }
        }
        public void RevertOperation(int numRevertCount = 1)
        {
            int newRevisionIndex = _ValueHistory.Count - 1 - numRevertCount;
            if (newRevisionIndex < 0) newRevisionIndex = 0;
            double val = _ValueHistory[newRevisionIndex];
            _ValueHistory.RemoveRange(newRevisionIndex + 1, _ValueHistory.Count - 1 - newRevisionIndex);
            this._Value = val;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
