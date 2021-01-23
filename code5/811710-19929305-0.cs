    var _viewModelFactory = MockRepository.GenerateStub<IViewModelFactory>();
    viewModelFactory.Stub(x => x.Create<ViewModel1>(Arg<int>.Is.Anything))
                       .Return(null)
                       .WhenCalled(x => {
                           var id = (int)x.Arguments[0];
                           x.ReturnValue = new ViewModel1(id);
                        });
