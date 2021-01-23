        private void button1_Click(object sender, EventArgs e)
        {
            Action action2 = () => Console.WriteLine("Action 2");
            Action action1 = () =>
                {
                    Console.WriteLine("Action1");
                    BeginInvoke((MethodInvoker)delegate
                    {
                        action2();
                    });
                };
            action1();
        }
