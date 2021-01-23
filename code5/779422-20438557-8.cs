		public class AddressController 
			: AccountObjectController
		{
			...
			// GET api/Address
			public ICollection<Address> Get()
			{
				//This returns back the calling Hub action.
				return Account.Addresses;
			}
			...
		}
