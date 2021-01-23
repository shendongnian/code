    [TestMethod]
    public void VerifyLoadCompareDifferentOrder() {
        var parameters = new List<NotificationParameter> {
            new NotificationParameter("A", 1),
            new NotificationParameter("B", 2),
            new NotificationParameter("C", 3),
        };
        var expected = new List<NotificationParameter> {
            new NotificationParameter("B", 2),
            new NotificationParameter("C", 3),
            new NotificationParameter("A", 1),
        };
        var mockService = new Mock<IService>();
        var client = new ClientClass(mockService.Object);
        client.Run(parameters);
        mockService.Verify(mk => mk.Load(It.Is<IEnumerable<NotificationParameter>>(it => AreSame(expected, it))));
    }
    private static bool AreSame(
        IEnumerable<NotificationParameter> expected,
        IEnumerable<NotificationParameter> actual
    ) {
        var ret = expected.OrderBy(e => e.Key).SequenceEqual(actual.OrderBy(a => a.Key), Comparer);
        return ret;
    }
