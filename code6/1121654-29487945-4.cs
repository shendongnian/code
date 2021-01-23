    public class MessageBoxUserConfirmation : IUserConfirmation
    {
        public bool Confirm(string title, string message)
        {
            return MessageBox.Show(title, message) == true;
        }
    }
    public class TestUserConfirmation: IUserConfirmation
    {
        public bool Result { get; set; }
        public bool Confirm(string title, string message)
        {
            return this.Result;
        }
    }
