    public class TestService : ITestService
    {
        private ITransactionRepository transRepo = DataAccess.transRepo;
        private IAccountRepository accountRepo = DataAccess.accountRepo;
        private ISystemsRepository sysRepo = DataAccess.sysRepo;
        private IScheduleRepository schRepo = DataAccess.schRepo ;
        private IProfileRepository profileRepo = DataAccess.profileRepo;
    }
