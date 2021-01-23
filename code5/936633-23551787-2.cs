    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Text;
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
		public void UpdateBatchCampaignContacts(int campaignId, IList<int> ids)
		{
			if (ids == null) return;
			if (ids.Count == 0) return;
			var idsToUpdate = new StringBuilder();
			foreach (var id in ids)
			{
				idsToUpdate.AppendFormat(",{0}", id);
			}
			Database.ExecuteSqlCommand("UPDATE CampaignContacts SET CampaignId = @campaignId WHERE EmailContactId in (@contactIds)",
				new SqlParameter("@campaignId", campaignId),
				new SqlParameter("@contactIds", idsToUpdate.ToString().Remove(0, 1)));
		}
	}
