    catch (PayPal.Exception.PayPalException ex)
    {
        string error = "";
        if (ex.InnerException is PayPal.Exception.ConnectionException)
        {
            var paypalError = JsonConvert.DeserializeObject<PaypalApiError>(((PayPal.Exception.ConnectionException)ex.InnerException).Response);
            // method below would parse name/details and return a error message
            error = ParsePaypalError(paypalError);
        }
        else
        {
            error = ex.Message;
        }
        return new PaymentDataResult(){ 
                Success = false,
                Message = error
            };
    } 
