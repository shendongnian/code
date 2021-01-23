<pre>
msgset.Attributes.OnError = ENRqOnError.roeContinue;
string[] InvoiceList = { "144", "9999" };
foreach (string invNum in InvoiceList)
{
    IInvoiceQuery invQuery = msgset.AppendInvoiceQueryRq();
    invQuery.ORInvoiceQuery.RefNumberList.Add(invNum);
}
// Process the requests and get the response
IMsgSetResponse MsgResponse = SessionManager.DoRequests(msgset);
                
// Check each response
for (int index = 0; index < MsgResponse.ResponseList.Count; index++)
{
	IResponse response = MsgResponse.ResponseList.GetAt(index);
	if (response.StatusCode != 0)
        {
            // Save the invoice number in the "not found" file
            // and display the error
            MessageBox.Show("Error finding invoice " + InvoiceList[index] + ". Error: " + response.StatusMessage);
        }
}
