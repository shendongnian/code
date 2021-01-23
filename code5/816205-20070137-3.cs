    [Test]
    public void EmployeeType_Manager_HasBonusService()
    {
        Container container = new Container();
        container.Register<IBonusService, BonusServiceStub>();
        container.Verify();
        EmployeeType.BonusService = () => container.GetInstance<IBonusService>();
        EmployeeType manager = EmployeeType.Manager;
        Assert.That(manager.BonusSize == 999m);
    }
    public class BonusServiceStub : IBonusService
    {
        public decimal currentManagerBonus
        {
            get 
            {
                return 999m;
            }
        }
    }
