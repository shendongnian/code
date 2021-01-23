    public class MySwitch<T> : Dictionary<T, Action<T>>
    {
        private Action<T> _defaultAction;
        public void TryInvoke(T value)
        {
            Action<T> action;
            if (TryGetValue(value, out action))
            {
                action(value);
            }
            else
            {
                var defaultAction = _defaultAction;
                if (defaultAction != null)
                {
                    defaultAction(value);
                }
            }
        }
        public void SetDefault(Action<T> defaultAction)
        {
            _defaultAction = defaultAction;
        }
    }
