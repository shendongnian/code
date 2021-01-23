    IQualityIssuesRepository qir = new QualityIssuesRepository();
            Mock<IQualityIssuesRepository> qualityIssuesRepository = new Mock<IQualityIssuesRepository>();
    qualityIssuesRepository.CallBase = true;
    Action<List<int>, int> saveNotification = qir.SaveNotification;
    qualityIssuesRepository.Setup(p => p.SaveNotification(It.IsAny<List<int>>(), It.IsAny<int>()))
                .Callback(saveNotification);
