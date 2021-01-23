        public static void Example1c()
        {
            Action<int> action = DoSomethingCool;
            TimeSpan span = new TimeSpan(0, 0, 0, 5);
            int number = 10;
            ThreadStart start = delegate { RunAfterTimespan(action, span, number); };
            Thread t4 = new Thread(start);
            t4.Start();
            MessageBox.Show("Thread has been launched");
        }
        public static void RunAfterTimespan(Action<int> action, TimeSpan span, int number)
        {
            Thread.Sleep(span);
            action(number);
        }
        private static void DoSomethingCool(int number)
        {
            MessageBox.Show("I'm doing something cool");
        }
