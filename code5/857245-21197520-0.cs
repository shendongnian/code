        class MyDelayedCaller<T1> : IMyDelayedCaller
        {
            private Action<T1> _target;
            public T1 _param;
            public MyDelayedCaller(Action<T1> target, T1 parameter)
            {
                _target = target;
                _param = parameter;
            }
            public void Invoke()
            {
                _target(_param);
            }
        }
        class MyDelayedCaller<T1, T2> : IMyDelayedCaller
        {
            private Action<T1, T2> _target;
            public T1 _param1;
            public T2 _param2;
            public MyDelayedCaller(Action<T1, T2> target, T1 param1, T2 param2)
            {
                _target = target;
                _param1 = param1;
                _param2 = param2;
            }
            public void Invoke()
            {
                _target(_param1, _param2);
            }
        }
