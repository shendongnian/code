        public void TestUsingExternalDependency()
        {
            _repo.Setup(r => r.GetData())
                .Returns(Task.Run(() => 5))
                .Verifiable();
            _vm.LoadJobCommand.Execute(null);
            _repo.VerifyAll();
        }
