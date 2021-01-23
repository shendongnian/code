	class SemaphoreConcurrencyHelper: IConcurrencyHelper
	{
		private Semaphore _semaphore;
		public bool AcquireLock(string LockId, int Instances)
		{
			try
			{
				_semaphore = Semaphore.OpenExisting(GenerateMutexId(LockId)); //Acquire existing Semaphore (if exists)                   
			}
			catch (WaitHandleCannotBeOpenedException) // Create new Semaphore if not exists
			{
				_semaphore = new Semaphore(Instances, Instances, GenerateMutexId(LockId));                
			}
			return _semaphore.WaitOne(TimeSpan.FromSeconds(10), false); // Block thread until Semaphore has slot available within specified Timespan
		}
		public bool ReleaseLock()
		{
			try
			{
				_semaphore.Release(1); // Increment the count on the Sempahore by 1
			}
			catch (Exception e)
			{
				return false; //TODO: Add an error log
			}
			_semaphore = null;
			return true;
		}
		private string GenerateMutexId(string LockId)
		{
			// Get application GUID as defined in AssemblyInfo.cs
			string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
			appGuid = appGuid + LockId;
			// Unique id for global mutex - Global prefix means it is available system wide
			return string.Format("Global\\{{{0}}}", appGuid);
		}
	}
	
