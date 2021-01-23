     using (mocks.Ordered())
     {
       Expect.Call(mockAuthenticateDA.GetScope)
             .Return(null);
       Expect.Call(() => mockAuthenticateDA.Check(
              null, "orgadata", "test", "test", "branch", "customer",
              out customerId, out userId))
             .Return(eCheckResult.cOK);
       Expect.Call(() => mockAuthenticateDA.GetRightAssignment(null, "userId"))
             .Return(MockupDA.Rights);
     }
     mocks.ReplayAll();
     using (mocks.Playback())
     {
          var result = testClass.Authenticate(identity, identityReference);
     }
