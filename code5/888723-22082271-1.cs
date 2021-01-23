	public interface ILogicChecker
	{
		bool Getboolean();
	}
	public class LogicChecker : ILogicChecker
	{
		public bool Getboolean()
		{
			//.....
			if (someConditions)
				return true;
			else
				return false;
		}
	}
	public class Service
	{
		ILogicChecker logicChecker;
		Status status;
		public Service(ILogicChecker logicChecker)
		{
			this.logicChecker = logicChecker;
		}
		public void CheckService()
		{
			//...
			if (logicChecker.Getboolean())
			{
				status = Status.Pass;
			}
			else
			{
				status = Status.NotPass;
			}
		}
	}
	public enum Status
	{
		Pass = 0,
		NotPass = 1
	}
