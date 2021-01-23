    [Test]
    public void Api_GetDataUsingDataContractWithNullParameter_ThrowsArgumentNullException()
    {
        var api = new Api();
        var exception = Assert.Throws<ArgumentNullException>(() => api.GetDataUsingDataContract(null));
        Assert.That(exception.Message, Is.Not.Null.Or.Empty);
        Assert.That(exception.Message, Is.StringContaining("source"));
    }
