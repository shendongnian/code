    [TestMethod]
    public async Task CreateAsyncViewModel()
    {
      // other stuff
      var result =  vmMapper.CreateViewModel(mock1, mock2);
      var viewModel = await result;
      Assert.AreEqual(viewModel.Data.Count(), 1);
    }
