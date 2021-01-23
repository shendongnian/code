    public interface IDao
    {
    	IEnumerable<ConfigurationEntity> Get(Expression<Func<ConfigurationEntity, bool>> expression) {...}
    }
    var daoMock = new Mock<IDao>();
    
    daoMock.Setup(d => d.Get(It.Is<Expression<Func<ConfigurationEntity, bool>>>(e => ExpressionMatchesEntityWithKey(e, TestKey))))
                   .Returns(new List<ConfigurationEntity> {configEntity});
