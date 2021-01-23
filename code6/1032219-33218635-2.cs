    public class EfFactory : IRepoFactory
    
    {
	    public ITransactionRepositry TransRepo { return new TransactionRepository();}
	    public IAccountRepository AccountRepo {return new AccountRepository();}
	    public ISystemsRepository SysRepo {return new SystemRepository();}
	    public IScheduleRepository SchRepo {return new SchRepository();}
	    public IProfileRepository ProfileRepo {return new ProfileRepository();}
    }
