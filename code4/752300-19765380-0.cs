    // Controller
    [HttpPost]
    public ActionResult Send(BitcoinTransactionViewModel transaction)
    {
    }
    // View
    @using (Html.BeginForm("Send", "DepositDetails", FormMethod.Post, new { transaction = Model }))
    {
    
    @Html.HiddenFor(m => m.Token);
    @Html.HiddenFor(m => m.Transaction.TransactionId);
    .
    .
