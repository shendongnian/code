    private static void FakeClientsLoading(MyClass fakeClass, IEnumerable<string> clientsToLoad)
    {
        fakeClass.Stub(
            x =>
                x.LoadClientsFromDb(Arg<string>.Is.Anything,
                    out Arg<object>.Out(null).Dummy))
            .Do(
                new LoadClientsFromDbAction(
                    (string someString, out object outParam) =>
                    {
                        outParam = null;
                        TestHelper.LoadClients(someString, clientsToLoad);
                    }
                    ));
    }
