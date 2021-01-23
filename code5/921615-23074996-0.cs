	public class Contact : EntityBase
	{
		private string _firstName;
		
		[NotifyChange]
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				ChangeState();
				_firstName = value;
			}
		}
		private void ChangeState()
		{
		   EntityState = EntityState.Modified;
		}
	}
