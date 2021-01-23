    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static bool CheckInvoiceExists(string vendorNumber, string invoiceNumber)
        {
            try
            {
                return RequestEntry.CheckInvoiceExists(vendorNumber, invoiceNumber);
            }
            catch (Exception exp)
            {
                EventLogging.LogError("Error checking if invoice exists: " + exp.Message);
                return false;
            }
        }
