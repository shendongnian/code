	[Test]
    public void DeleteAppointment_Valid_DeletedRecordId()
    {
        //Setup
        var dbContextMock = new Mock<IDataContextProvider>();
        var dataAdapterMock = new Mock<IDataContext<IDataAdapterRW>>();
        dbContextMock.Setup(d => d.GetContextRW())
            .Returns(dataAdapterMock.Object);
        dataAdapterMock.Setup(a => a.Run(It.IsAny<Action<IDataAdapterRW>>()))
                       .Returns(new List<uint>{ 1 }); // configure the mock to return the list
        var calendarService = new CalendarService(dbContextMock.Object);
        //Run
		int id = 1;
        var result = calendarService.DeleteAppointment(id);
        //Assert
        var isInList = result.Contains(id);
        Assert.AreEqual(isInList, true);
    }
