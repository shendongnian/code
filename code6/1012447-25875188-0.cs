    public void DeleteOrganization(Guid actorId)
	{
		using (var session = _nhibernate.OpenSession())
		{
			ITransaction transaction = session.BeginTransaction();
			try
			{
				var Organization = (from p in session.Query<Organization>()
										   where p.ActorId == actorId
										   orderby p
										   select p).First();
				session.Delete(Organization);
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}
	}
