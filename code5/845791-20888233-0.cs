    // Message container
    public class AccountChangedMessage : GalaSoft.MvvmLight.Messaging.GenericMessage<Account>
    {
        public AccountChangedMessage(Account a) : base(a) { }
    }
    // Dependent ViewModel
    public class AccountsViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public AccountsViewModel()
        {
            MessengerInstance.Register<AccountChangedMessage>(this, OnAccountChanged);
        }
        private void OnAccountChanged(AccountChangedMessage msg)
        {
            // TODO: Rebuild bound data
        }
    }
    // Initiating ViewModel
    public class AccountEditViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public void SaveAccount()
        {
            _accountService.Save(_account);
            MessengerInstance.Send(new AccountChangedMessage(_account));
        }
    }
