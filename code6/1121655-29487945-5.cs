    var confirmation = new TestConfirmation();
    var viewModel = new ViewModel(confirmation);
    // simulate a user clicking "Cancel"
    confirmation.Result = false;
    viewModel.MyCommand.Execute(...);
    // verify that nothing happened
