	[Test]
    public void DeleteAppointment_Valid_DeletedRecordId()
    {
        //Setup
        var dbContextMock = new Mock<IDataContextProvider>();
        var dataAdapterMock = new Mock<IDataContext<IDataAdapterRW>>();
        dbContextMock.Setup(d => d.GetContextRW())
            .Returns(dataAdapterMock.Object);
        dataAdapterMock.Setup(a => a.Run(It.IsAny<Func<IDataAdapterRW, IEnumerable<uint>>>()))
                       .Returns((Func<IDataAdapterRW, IEnumerable<uint>> func) => { return func(dataAdapterMock.Object);}); // configure the mock to return the list
        var calendarService = new CalendarService(dbContextMock.Object);
        //Run
		int id = 1;
        var result = calendarService.DeleteAppointment(id);
        //Assert
        var isInList = result.Contains(id); // verify the result if contains the
        Assert.AreEqual(isInList, true);
    }
