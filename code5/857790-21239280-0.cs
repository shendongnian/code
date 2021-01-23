IResponse invoiceResponse = invoiceResponseMsgSet.ResponseList.GetAt(0);
if(invoiceResponse.StatusCode !=0)
{
    // There was an error with the request.
    string errorMsg = invoiceResponse.StatusMessage;
}
