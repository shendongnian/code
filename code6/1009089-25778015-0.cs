     public class OrderPaymentVm : ViewModelBase
     {
      public OrderPaymentVm ()
      {
         CopyPaymentTransactionId = new RelayCommand(ExecuteCopyPaymentTransactionId));
      }
      
    .
    .
    .
      public RelayCommand CopyPaymentTransactionId
      {
         get; set;
      }
      private void ExecuteCopyPaymentTransactionId()
      {
         Clipboard.SetText(string.IsNullOrWhiteSpace(PaymentTransactionId) ? string.Empty : PaymentTransactionId);
      }
   }
