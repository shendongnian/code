    [ServiceBehavior(
		UseSynchronizationContext = false,
		InstanceContextMode = InstanceContextMode.Single, 
		ConcurrencyMode = ConcurrencyMode.Multiple, 
		IncludeExceptionDetailInFaults = true)]
    public class ContractServer : IContract 
	{
        public void CallServer() 
		{
            MessageBox.Show("Client called!");
        }
    }
