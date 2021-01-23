    [TestMethod]
    public void TestUploadCallsMadeThroughActionRunner() {
        var uploader = new Mock<IUploader>();
        var runner = new Mock<IActionRunner>();
        var token = new CancellationToken();
        int callCount = 0;
        uploader.Setup(a => a.Upload(token, It.IsAny<string>())).Callback(() => callCount++);
        // Use callback to invoke actions supplied to runner
        runner.Setup(x => x.ExecIfNotCancelled(token, It.IsAny<Action>()))
              .Callback<CancellationToken, Action>((tok,act)=>act());
        var engine = new UploadEngine(uploader.Object, runner.Object);
        engine.PerformUpload(token);
        Assert.IsTrue(callCount > 0);
    }
    [TestMethod]
    public void TestNoUploadCallsMadeThroughWithoutActionRunner() {
        var uploader = new Mock<IUploader>();
        var runner = new Mock<IActionRunner>();
        var token = new CancellationToken();
        int callCount = 0;
        uploader.Setup(a => a.Upload(token, It.IsAny<string>())).Callback(() => callCount++);
        // NOP callback on runner prevents uploader action being run
        runner.Setup(x => x.ExecIfNotCancelled(token, It.IsAny<Action>()))
              .Callback<CancellationToken, Action>((tok, act) => { });
        var engine = new UploadEngine(uploader.Object, runner.Object);
        engine.PerformUpload(token);
        Assert.AreEqual(0, callCount);
    }
