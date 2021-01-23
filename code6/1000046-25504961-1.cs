    [TestMethod]
    public void WordCounterViewModelTest()
    {
        var mock = new Mock<IObservable<string>>();
        var vm = new WordCounterViewModel(mock.Object);
    
        vm.WordCount.Should().Be(0);
    
        vm.TextInput = "bla!";
        vm.WordCount.Should().Be(1);
    
        vm.TextInput = "bla, bla!!";
        vm.WordCount.Should().Be(2);
    }
