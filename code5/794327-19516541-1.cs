	namespace Service
	{
		class MyService: IMyService
		{
			public void MyOperation()
			{
				try
				{
					var businessLogic = new BusinessLogic();
					businessLogic.DoOperation();
				}
				catch (KeyNotFoundException)
				{
					throw new FaultException<MyFaultContract>(new MyFaultContract
					{
						Problem = "A key issue occurred in the service"
					});
				}
				catch (Exception)
				{
					throw new FaultException<AnotherFaultContract>(new AnotherFaultContract
					{
						Description = "Something BAD happened in the service"
					});
				}
			}
		}
	}
	
