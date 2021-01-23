    var outBuffer = new byte[512];
    var fileWrap = new Mock<IFileWrap>();
    var fileStreamWrap = new Mock<IFileStreamWrap>();
    var stream = new Mock<IFileStreamWrap>();
    fileStreamWrap.Setup(fsw => fsw.StreamInstance).Returns(new MemoryStream(outBuffer));
    //I'm using File.Create to create temporary files with DeleteOnClose flag in the application, which get disposed before the function returns
    fileWrap.Setup(fw => fw.Create(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<FileOptions>()))
        .Returns((string filepath, int i, FileOptions fo) =>
        {
            //I'm using filepath in a collection in my test to handle multiple files created in the application code
            return fileStreamWrap.Object;
        });
    //Call application code that creates temporary file and closes eagerly with dispose.
    //Application code will be something like:
    var tempFileStream = _fileWrap.Create(tempFileName, 4096, FileOptions.DeleteOnClose);
    using (var writer = new StreamWriter(tempFileStream.StreamInstance, Encoding.Default, 4096, true))
    {...}
    //Test file contents were written correctly into outBuffer
    var outString = System.Text.Encoding.UTF8.GetString(outBuffer);
    Assert.AreEqual("Important Business string", outString);
