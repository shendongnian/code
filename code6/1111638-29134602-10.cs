        [Test]
        public void TestUsingScheduler()
        {
            _repo.Setup(r => r.GetData()).Returns(Task.Run(() => 2));
            _vm = new ViewModelUnderTest(_repo.Object, new ImmediateScheduler());
            _vm.LoadJobCommand.Execute(null);
            _vm.Jobs.Should().NotBeEmpty();
        }
