    public class MySwitch2<T>
    {
        private readonly T _input;
        private bool _done = false;
        private MySwitch2(T input)
        {
            _input = input;
        }
        public MySwitch2<T> On(T input)
        {
            return new MySwitch2<T>(input);
        }
        public MySwitch2<T> Case(T caseValue, Action<T> action)
        {
            if (!_done && Equals(_input, caseValue))
            {
                _done = true;
                action(_input);
            }
            return this;
        }
        public void Default(Action<T> action)
        {
            if (!_done)
            {
                action(_input);
            }
        }
    }
