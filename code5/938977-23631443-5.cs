    Mock<IDnsWrapper> dnsMock = new Mock<IDnsWrapper>();
    dnsMock.Setup(d => d.GetHostEntry(It.IsAny<string>()))
           .Throws(new SocketException());
    var yourClass = new YourClass(dnsMock.Object); // inject interface implementation
    yourClass.DoSomethingWhichGetHostsEntry();
