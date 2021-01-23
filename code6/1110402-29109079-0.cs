    [TestMethod]
    public void TestAdmitPatView()
    {
    	var adc = new AdmissionController();
    	
    	adc.ControllerContext = A.Fake<ControllerContext>();
    	var fakePrincipal = A.Fake<IPrincipal>();
    	var fakeIdentity = new GenericIdentity( "username" );
    	A.CallTo( () => fakePrincipal.Identity ).Returns( fakeIdentity );
    	A.CallTo( () => HomeController.ControllerContext.HttpContext.User ).Returns( fakePrincipal );
    
    	var res = adc._AdmitPatient(6);
    
    	Assert.AreEqual(adm.PatientID, res.ViewData);
    }
