    [Test]
    public void EmployeeType_Manager_HasBonusService()
    {
        Container container = new Container();
        container.Register<IBonusService, BonusServiceStub>();
        EmployeeType.BonusService = () => container.GetInstance<IBonusService>();
        BonusServiceStub.constructed = false;
        container.Verify();
        //Verify has ensured the container can create instances of IBonusService
        Assert.That(BonusServiceStub.constructed, Is.True);
        EmployeeType manager = EmployeeType.Manager;
        Assert.That(manager.BonusSize == 999m);
    }
    public class BonusServiceStub : IBonusService
    {
        public static bool constructed = false;
        public BonusServiceStub() { constructed = true; }
        public decimal currentManagerBonus { get { return 999m; } }
    }
