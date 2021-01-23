        public static void Example1c()
        {
            Action action = DoSomethingCool;
            TimeSpan span = new TimeSpan(0, 0, 0, 5);
            ThreadStart start = delegate { RunAfterTimespan(action, span); };
            Thread t4 = new Thread(start);
            t4.Start();
            MessageBox.Show("Thread has been launched");
        }
        public static void RunAfterTimespan(Action action, TimeSpan span)
        {
            Thread.Sleep(span);
            action();
        }
        private static void DoSomethingCool()
        {
            MessageBox.Show("I'm doing something cool");
        }
