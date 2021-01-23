    [Test]
    public void test_validation()
    {
        var sut = new POSViewModel();
        // Set some properties here
        var context = new ValidationContext(sut, null, null);
    	var results = new List<ValidationResult>();
    	var isModelStateValid =Validator.TryValidateObject(sut, context, results, true);
    
        // Assert here
    }
