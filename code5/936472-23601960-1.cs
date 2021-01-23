    catch (PayPal.Exception.PayPalException ex)
    {
        if (ex.InnerException is PayPal.Exception.ConnectionException)
        {
            var paypalError = JsonConvert.DeserializeObject<PaypalApiError>(((PayPal.Exception.ConnectionException)ex.InnerException).Response);
            // returns PaymentDataResult
            return ParsePaypalError(paypalError);
        }
        else
        {
            return new PaymentDataResult(){ 
                Success: false,
                Message: ex.Message
            };
        }
    } 
