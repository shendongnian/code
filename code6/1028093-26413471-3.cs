    public static class DispatcherExtensions
    {
        public static T InvokeAndPump<T>(
            this Dispatcher dispatcher,
            Func<T> function,
            DispatcherPriority priority = DispatcherPriority.Normal)
        {
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");
            if (function == null)
                throw new ArgumentNullException("function");
            // If you've found this code in your project, you are doomed.  <3
            Action wait, notify;
            var currentDispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (currentDispatcher != null)
            {
                var frame = new DispatcherFrame();
                wait = () => Dispatcher.PushFrame(frame);
                notify = () => frame.Continue = false;
            }
            else
            {
                var waitEvent = new ManualResetEventSlim(false);
                wait = waitEvent.Wait;
                notify = waitEvent.Set;
            }
            var error = default(Exception);
            var result = default(T);
            dispatcher.BeginInvoke(
                priority,
                new Action(
                    () =>
                    {
                        try { result = function(); }
                        catch (Exception e) { error = e; }
                        finally { notify(); }
                    }));
            // Hold on to your butts...
            wait();
            if (error != null)
                throw new TargetInvocationException(error);
            return result;
        }
    }
