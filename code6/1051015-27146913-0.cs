	public class LoanViewModel 
	{
		public LoanViewModel()
		{
			IEventAggregator events = ... ; // get via ServiceLocator or via Constructor for DI
			events.GetEvent<CustomerLoadedEvent>().Subscribe(OnCustomerLoaded);
		}
		private void OnCustomerLoaded(Customer customer) 
		{
			int customerId = customer.ID;
			
			// do your query now
		}
	}
	public class OtherViewModel 
	{
		IEventAggregator events;
		
		public LoanViewModel()
		{
			this.events; = ... ; // get via ServiceLocator or via Constructor for DI
		}
		
		// Should be ICommand for WPF binding...assuming SelectedItem is from type Customer
		public void Open() 
		{
			if (SelectedItem != null)
			{
				events.GetEvent<CustomerLoadedEvent>().Publish(SelectedItem);
			}
			this.OnPropertyChanged("Items");
		}
	}
