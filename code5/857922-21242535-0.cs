<pre>
// Holds a list of our invoices to query for
List<string> InvoiceTxnIDList = new List<string>();
// Create payment query
IReceivePaymentQuery pmtQuery = MsgRequest.AppendReceivePaymentQueryRq();
pmtQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.FromTxnDate.SetValue(FromDate);
pmtQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.TxnDateRangeFilter.ORTxnDateRangeFilter.TxnDateFilter.ToTxnDate.SetValue(ToDate);
// Process query and get results
IMsgSetResponse MsgResponse = SessionManager.DoRequests(MsgRequest);
IResponse response = MsgResponse.ResponseList.GetAt(0);
if (response.StatusCode == 0)
    {
        IReceivePaymentRetList pmtRetList = (IReceivePaymentRetList)response.Detail;
                    
        // Loop through our payment list
        for (int index = 0; index < pmtRetList.Count; index++)
        {
            IReceivePaymentRet pmt = pmtRetList.GetAt(index);
                        
            // Check to see if we have any linked transactions
            if(pmt.AppliedToTxnRetList != null)
            {
                // Loop through all the linked transactions and see if it is
                // already on our query list
                for (int indey = 0; indey < pmt.AppliedToTxnRetList.Count; indey++)
                {
                    IAppliedToTxnRet appTxn = pmt.AppliedToTxnRetList.GetAt(indey);
                    if(!InvoiceTxnIDList.Contains(appTxn.TxnID.GetValue()))
                        InvoiceTxnIDList.Add(appTxn.TxnID.GetValue());
                }
            }
        }
    
    // Create a query for all the txnIDs that we found
    MsgRequest.ClearRequests();
    MsgRequest.Attributes.OnError = ENRqOnError.roeStop;
    for (int index = 0; index < InvoiceTxnIDList.Count; index++)
    {
        IInvoiceQuery invQuery = MsgRequest.AppendInvoiceQueryRq();
        invQuery.ORInvoiceQuery.TxnIDList.Add(InvoiceTxnIDList[index]);
    }
                    
    // Process the request and get the invoice ret list
    // *****
    // *****
</pre>
