    [Serializable]
    public class CancelableEventArgs : EventArgs
    {
        public MarshalByRefWrapper<bool> Cancel { get; set; }
    }
    public class MarshalByRefWrapper<T> : MarshalByRefObject
    {
        public T Value { get; set; }
    }
