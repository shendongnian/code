    [Test]
    public void Should_execute_command_the_number_of_times_specified() {
      var command = Substitute.For<ICommand>();
      var repeater = new CommandRepeater(command, 3);
      //Act
      repeater.Execute();
      //Assert
      command.Received(3).Execute(); // << This will fail if 2 or 4 calls were received
    }
