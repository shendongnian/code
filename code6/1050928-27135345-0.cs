        public static void InvokeIfNeeded(this Dispatcher dispatcher, Action action)
        {
            if (dispatcher == null || dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action, DispatcherPriority.Normal);
        }
