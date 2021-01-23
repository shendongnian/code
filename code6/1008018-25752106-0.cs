        [TestMethod]
		public void Fails()
		{
            bool isExecuted = false;
			bool canExecute = false;
			var command = new DelegateCommand(() => 
                                              {
                                                 Console.WriteLine(@"Execute");
                                                 isExecuted = true;
                                              }
											  () =>
											  {
												  Console.WriteLine(@"CanExecute");
												  return canExecute;
											  });
			
            // assert before execute
			Assert.IsFalse(IsExecuted);
            command.RaiseCanExecuteChanged();
			Assert.IsFalse(IsExecuted);
			canExecute = true;
            Assert.IsFalse(IsExecuted);
            command.RaiseCanExecuteChanged();
			Assert.IsTrue(IsExecuted);
		}
