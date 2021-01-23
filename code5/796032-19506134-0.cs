    public class YourController
    {
        public ActionResult Transaction()
            {
                List<Transaction> transactionList = new List<Transaction>().ToList();
                // Your logic here to populate transaction list
                TransactionModel model = new TransactionModel();
                model.TransactionList = transactionList;
                return PartialView("_Transaction", model);
            }
    }
