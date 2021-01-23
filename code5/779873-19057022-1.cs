       public static object GetTranslatedValueForPaymentMode(PaymentMode pm)
        {
    		if (backendSystem == "SAP)
    		{    
    			switch case (pm)
    			{
    				case PaymentMode.AMEX:
    					return "33"; //whatever code this is
    				case PaymentMode.VISA:
    					return "AVC"; //whatever code this is
    			}
    		}
    		else if (backendSystem == "GreatPains")
    		{
    			switch case (pm)
    			{
    				case PaymentMode.AMEX:
    					return new Guid("GKSKJDS"); //whatever code this is
    				case PaymentMode.VISA:
    					return new Guid("DADADA"); //whatever code this is
    			}
       		}
        }
