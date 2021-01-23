    public class UnitTest1
    {
    private MobileServiceContext _context = null;
    private GroupController _controller = null;
    [TestInitialize]
    public void SetupTest()
    {
        DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
        _context = new MobileServiceContext(connection);
        _controller = new GroupController();
        _controller.SetDomainManager(new EntityDomainManager<Group>(_context, _controller.Request));
    }
    [TestMethod]
    public void TestGetAll()
    {
        var result = _controller.GetAccessibleGroups();
    }
