    using Moq.Protected;
    ...
    // verify the call
    mock.Protected().Verify("RaisePropertyChanged", Times.Once(), "SearchTerm", true);
    // Note that "RaisePropertyChanged" is a string,
    // since the name RaisePropertyChanged is not in scope.
