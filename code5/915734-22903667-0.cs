            var stubCommandDispatcher = new Mock<ICommandDispatcher>();
            stubCommandDispatcher.Setup(x => x.Get<CanResponse>
                (It.IsAny<CanChangeCommand>()))
                .Returns(new CanResponse() {Can = true});
            var stubScheduleCommand = new Mock<CreateScheduleCommand>();
            var sut = new UpdateHandler(stubCommandDispatcher.Object);
            var r = sut.Handle(stubScheduleCommand.Object);
