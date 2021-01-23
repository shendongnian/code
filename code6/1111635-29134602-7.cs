        [Test]
        public void TestUsingExternalDependency()
        {
            _repo.Setup(r => r.GetData())
                .Returns(() => { throw new Exception("TEST"); })
                .Verifiable();
            try
            {
                _vm.LoadJobCommand.Execute(null);
            }
            catch (Exception e)
            {
                e.Message.Should().Be("TEST");
            }
            _repo.VerifyAll();
        }
