        static public void Observe(MethodInfo method, Action action)
        {
            new Observation(method, action).Manage(method.ReflectedType);
        }
        private MethodInfo m_Method;
        private Action m_Action;
        private Notification(MethodInfo method, Action action)
        {
            this.m_Method = method;
            this.m_Action = action;
        }
        override protected IEnumerable<Advice<T>> Advice<T>(MethodInfo method)
        {
            if (method == this.m_Method)
            {
                yield return Advice<T>.After(this.m_Action);
            }
        }
    }
