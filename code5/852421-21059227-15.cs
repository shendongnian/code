    public class MyViewModel : ViewModelBase
    {
        public MyViewModel(string token)
            : base(token)
        {
        }
        //say OP want to open window on Command Execute
        public void OnCommand()
        {
            Messanger.Instance.SendMessage(Token, new Message(MessageType.OpenWindow, "MyChildWindow"));
        }
    }
