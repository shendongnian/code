    // Controller
    [HttpPost]
    public ActionResult Send(BitcoinTransactionViewModel **RedeemTransaction**)
    {
    }
    // View
    @using (Html.BeginForm("Send", "DepositDetails", FormMethod.Post, new { **RedeemTransaction** = Model }))
    {
    
    @Html.HiddenFor(m => m.Token);
    @Html.HiddenFor(m => m.Transaction.TransactionId);
    .
    .
