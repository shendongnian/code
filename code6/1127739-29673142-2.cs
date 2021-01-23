	public class Employee
	{
		private Company company;
		public Company Company
		{
			get { return this.company; }
			set
			{
				this.company = value;
				UpdateCompanyPreferredContactMethod();
			}
		}
	
		private ContactMethods? preferredContactMethod;
		public ContactMethods? PreferredContactMethod 
		{
			get { return this.preferredContactMethod; }
			set
			{
				this.preferredContactMethod = value;
				UpdateCompanyPreferredContactMethod();
			}
		}
	
		private void UpdateCompanyPreferredContactMethod()
		{
			if (PreferredContactMethod == null)
			{
				PreferredContactMethod = company != null ?company.PreferredContactMethod : null;
			}
		}
	}
    
