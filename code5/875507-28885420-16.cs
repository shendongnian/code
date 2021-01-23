    public static partial class Ext
    {
        #region Public Methods
        public static Task ToTask(Action action)
        {
            return Task.Run(action);
        }
        public static Task<T> ToTask<T>(Func<T> function)
        {
            return Task.Run(function);
        }
        public static async Task ToTaskAsync(Action action)
        {
            return await Task.Run(action);
        }
        public static async Task<T> ToTaskAsync<T>(Func<T> function)
        {
            return await Task.Run(function);
        }
        #endregion Public Methods
    }
