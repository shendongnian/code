    [TestMethod()]
    public void PerformUpladerRegistrationTest()
    {
        var random = new Random();
        int batchSize = random.Next(int.MaxValue);
        var token = new CancellationToken();
        var uploadModuleMock = new Mock<IUploadModule>();
        uploadModuleMock.Setup(module => module.Upload(token, batchSize)).Verifiable();
        uploader.PerformUpload(uploadModuleMock.Object, token, batchSize);
        uploadModuleMock.Verify();
    }
