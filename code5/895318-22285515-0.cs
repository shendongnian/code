    public class MethodCompletedEventArgs : EventArgs
    {
        private MethodInfo m_method;
        private Boolean m_result;
        public MethodCompletedEventArgs(MethodInfo mi, Boolean result)
        {
            m_method = mi;
            m_result = result;
        }
        public MethodInfo Method { get { return m_method; } }
        public Boolean Result { get { return m_result; } }
    }
