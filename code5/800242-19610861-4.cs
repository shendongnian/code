    public class UserCredentialsVM : ViewModelBase
    {
        public UserCredentialsVM()
        {
            Messenger.Default.Register<System.Windows.Visibility>(this,
                "UserCredentialsVisible",
                msg => { Console.WriteLine(msg); });
        }
    }
