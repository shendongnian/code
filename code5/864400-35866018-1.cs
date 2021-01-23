      public class NavigateToTakePaymentCommand : ICommand
      {
            public NavigateToTakePaymentCommand(PaymentViewModel paymentViewModel)
            {
                ViewModel = paymentViewModel;
            }
            public PaymentViewModel ViewModel { get; set; }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
             //your implementation stuff goes here.
            }
            public event EventHandler CanExecuteChanged;
      }
