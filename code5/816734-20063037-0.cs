    static partial class MyExtensions
    {
        public static TResult SafeInvoke<T, TResult>(this T isi, Func<T, TResult> callFunction) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired)
            {
                IAsyncResult result = isi.BeginInvoke(callFunction, new object[] { isi });
                object endResult = isi.EndInvoke(result); return (TResult)endResult;
            }
            else
                return callFunction(isi);
        }
        /// <summary>
        /// This can be used in C# with:
        /// txtMyTextBox.SafeInvoke(d => d.Text = "This is my new Text value.");
        /// or:
        /// txtMyTextBox.SafeInvoke(d => d.Text = myTextStringVariable);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isi"></param>
        /// <param name="callFunction"></param>
        public static void SafeInvoke<T>(this T isi, Action<T> callFunction) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired) isi.BeginInvoke(callFunction, new object[] { isi });
            else
                callFunction(isi);
        }
    } // static class MyExtensions
