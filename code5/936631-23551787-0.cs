    public class YourDbContext : DbContext
	{
		public void DeleteBatchCampaignContacts(IList<int> ids)
		{
			if (ids == null) return;
			if (ids.Count == 0) return;
			var idsToDelete = new StringBuilder();
			foreach (var id in ids)
			{
				idsToDelete.AppendFormat(",{0}", id);
			}
			Database.ExecuteSqlCommand("DELETE FROM CampaignContacts WHERE EmailContactId in (@contactIds)", 
				new SqlParameter("@contactIds", idsToDelete.ToString().Remove(0, 1)));
		}
	}
