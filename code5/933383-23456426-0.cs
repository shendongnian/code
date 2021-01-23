		public void DeleteLicense(int licenseId)
		{
			var entityToDelete = context.Licenses.Find(licenseId);
			entityToDelete.Account = null;
			context.Licenses.Remove(entityToDelete);
		}
