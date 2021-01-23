    var mockBLL = MockRepository.GenerateMock<IBLL>();
    mockBLL.Stub(x => x.SaveOrUpdateDTO(null, null))
                       .IgnoreArguments()
                       .Repeat.Twice()           // Allow to be called twice
                       .WhenCalled(invocation =>
                {
                    if (nSaveOrUpdateCount > 0)  // throw an exception if 2nd invocation
                        throw new Exception();
                    nSaveOrUpdateCount++;
                });
    SimpleIoc.Default.Register<IBLL>(() => mockBLL);
