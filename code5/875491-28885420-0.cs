     public static partial class Ext
    {
        #region Public Methods
        public static Task ToTaskAsync(Action action)
        {
            if(null == action) return default(Task);
            return Task.Run(action);
        }
        public static Task<T> ToTaskAsync<T>(Func<T> function)
        {
            if(null == function) return default(Task<T>);
            return Task.Run(function);
        }
        #endregion Public Methods
    }
