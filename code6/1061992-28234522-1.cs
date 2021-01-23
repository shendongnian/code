    using System;
    using System.Threading;
    using System.Windows.Forms;
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            CreateFormAndStartMessagePump(() => CreateForm("first"), OnException, OnException, false, "pumpThread1");
            CreateFormAndStartMessagePump(() => CreateForm("second"), OnException, OnException, false, "pumpThread2");
            // note app shutdown not handled here
        }
        private static T CreateFormAndStartMessagePump<T>(
            Func<T> createForm,
            ThreadExceptionEventHandler onThreadException,
            UnhandledExceptionEventHandler onDomainException,
            bool isBackground,
            string name) where T : Form
        {
            var latch = new ManualResetEvent(false);
            T form = null;
            var thread = new Thread(ts =>
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += onThreadException;
                AppDomain.CurrentDomain.UnhandledException += onDomainException;
                form = createForm();
                latch.Set();
                Application.Run();
            })
            {
                IsBackground = isBackground,
                Name = name
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            latch.WaitOne();
            return form;
        }
        private static Form CreateForm(string name)
        {
            var form = new Form();
            form.Text = name;
            form.Show();
            return form;
        }
        private static void OnException(object sender, UnhandledExceptionEventArgs e)
        {
            // ...
        }
        private static void OnException(object sender, ThreadExceptionEventArgs e)
        {
            // ...
        }
    }
