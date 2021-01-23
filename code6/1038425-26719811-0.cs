	public class AccountReminder
	{
		private readonly IUnitOfWork _uow;
		private readonly ISendExpiringEmail _sendExpiringEmail;
		public AccountReminder(IUnitOfWork uow, ISendExpiringEmail sendExpiringEmail)
		{
			_uow = uow;
			_sendExpiringEmail = sendExpiringEmail;
		}
		public void NotifyUpcomingExpiringAccounts()
		{
			// Establish dates
			DateTime accountWarningDateTime = DateTime.Now.AddDays(-30).Date;
			DateTime expirationDateTime = DateTime.Now.AddDays(-45).Date;
			// Retrieve users whose accounts are either about to expire or have already expired
			var users = _uow.UserRepository
				.FindBy(element => (DbFunctions.TruncateTime(element.LastLoginDate) == accountWarningDateTime));
			foreach (var user in users)
			{
				SendReminder(user);
			}
			DisableExpiringAccounts(expirationDateTime);
		}
		
		private void SendReminder(User user)
		{
			// pass a model to a view to generate the HTML
			// the razor implementation should also handle plain-text vs. html mail; you can have two separate templates
			string htmlBody = MyRazorImplementation.GenerateBody(user); 
			_sendExpiringEmail.SendTo(new[] { user.Email }, "EmailSubject", htmlView, plainView);
		}
		private void DisableExpiringAccounts(DateTime expirationDateTime)
		{
			var expiredUsers = _uow.UserRepository.FindBy(element => element.Enabled && (DbFunctions.TruncateTime(element.LastLoginDate) <= expirationDateTime));
			foreach (var user in expiredUsers)
			{
				user.Enabled = false;
			}
			if (expiredUsers.Count > 0)
			{
				_uow.SaveChanges();
			}
		}
	}
