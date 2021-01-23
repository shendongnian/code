    public class MyCallBack : IServiceCallback
    {
        private static Action<string> _changeText = null;
    public static void SetDelegate(Action<string> nAction)
    {
        _changeText = nAction;
    }
    public void JoinServiceCallback(string message)
    {
        if(_changeText != null)
        {
            _changeText(message);
        }
    }
    }
    public partial class WinClient : Form
    {
    public WinClient(Customer customer)
    {
        MyCallBack.SetDelegate(SetLabelMsg);
    	public void SetLabelMsg(string message)
    	{
            lblMsg.Text = message;
    	}
    }
    }
