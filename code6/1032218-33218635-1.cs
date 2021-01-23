    public interface IRepoFactory
    {
        ITransactionRepository TransRepo {get;}
	    IAccountRepository AccountRepo {get;}
	    ISystemsRepository SysRepo {get;}
	    IScheduleRepository SchRepo {get;}
	    IProfileRepository ProfileRepo {get;}
    }
