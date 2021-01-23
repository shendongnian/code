    public static bool RequestIsValid(IPaymentRequest preAuthorizeRequest)
    {
        var classA = preAuthorizeRequest as PaymentRequestClassA;
        var classB = preAuthorizeRequest as PaymentRequestClassB;
        if (classA != null)
        {
             // handle PaymentRequestTypeA
        }
        else if (classB != null)
        {
             // handle PaymentRequestTypeB
        }
    }
