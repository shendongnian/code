    static void SetUpAStub<T>() 
            where T : new()
        {
            var stub = MockRepository.GenerateStub<IMyInterface>();
            stub.Stub(i => i.MyMethod<T>(null, false, string.Empty, string.Empty, string.Empty))
                .Return(new TaskFactory().StartNew( () => new T()));
        }
