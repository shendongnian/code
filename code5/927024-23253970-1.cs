    [TestCase("aZ13579")]
    public void ValidateInputOkTest()
    {
      var vm = new MyScreenViewModel();
      vm.UserInput = "SomeValidText";
    
      Assert.IsTrue(vm.UserInputIsValid);
    }
    
    [TestCase("aZ13580")]
    public void ValidateInputNotOkTest()
    {
      var vm = new MyScreenViewModel();
      vm.UserInput = "SomeInvalidText";
    
      Assert.IsFalse(vm.UserInputIsValid);
    }
