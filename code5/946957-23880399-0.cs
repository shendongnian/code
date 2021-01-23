    public partial class MessageWindow : Window
    {
        private MessageWindow()
        {
            InitializeComponent();
        }
        public static void Show(string text, string caption, int timeout)
        {
            var msgWindow = new MessageWindow()
                {
                    Title = caption
                };
            Task.Factory.StartNew(() =>
                {
                    for (var n = 0; n < timeout; n++)
                    {
                        msgWindow.Dispatcher.Invoke(() =>
                            {
                                msgWindow.text.Text = string.Format("{0}{1}{2}s left...", text, Environment.NewLine, timeout - n);
                            });
                        
                        System.Threading.Thread.Sleep(1000);
                    }
                    msgWindow.Dispatcher.Invoke(msgWindow.Close);
                });
            msgWindow.ShowDialog();
        }
    }
