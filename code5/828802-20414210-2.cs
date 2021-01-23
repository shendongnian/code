    public partial class WinClient : Form
    {
        public WinClient()
        {
            InitializeComponent();
            // Attach the "SetLabelMsg" method to the event
            MyCallBack.AfterJoinServiceCallback += SetLabelMsg;
            // Attach the "ShowMessage" method to the event
            MyCallBack.AfterJoinServiceCallback += ShowMessage;
        }
        private void SetLabelMsg(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                // Update the status label
                lblMsg.Text = string.Format("Time: {1}\t\tMessage: {0}", message, DateTime.Now);
            }
        }
        private void ShowMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                // Add the message to a listbox of all messages
                listLog.Items.Add(string.Format("Time: {1}\t\tMessage: {0}", message, DateTime.Now));
            }
        }
    }
	
    public class MyCallBack : IServiceCallback
    {
        public delegate void SendMessage(string message);
        public static event SendMessage AfterJoinServiceCallback;
        public void JoinServiceCallback(string message)
        {
            if (AfterJoinServiceCallback != null)
            {
                AfterJoinServiceCallback(message);
            }
        }
    }
