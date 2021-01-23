    decimal mockedFunction(ClassName instance, decimal dChkAmt, bool blnAddTo, bool blnIncludeRBL, ref ICharge oCharge)
    {
    	// ... assign oCharge?
    	return 20m;
    }
    
    [TestMethod]
    public void MyTest()
    {
    	using (ShimsContext.Create())
    	{
    		ShimClassName.AllInstances.addToSubtractFromCheckAmountDecimalBooleanBooleanIChargeRef
    			= mockedFunction;
    		
    		// ...continue with test
    	}
    }
